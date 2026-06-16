# Mini Curso: Grafos No Dirigidos y el Módulo Puntos de Acopio

---

## 1. ¿Qué es un Grafo?

Un **grafo** es una estructura de datos que modela **relaciones entre objetos**. A diferencia de una lista (lineal) o un árbol (jerárquico), un grafo puede representar conexiones arbitrarias entre cualquier par de elementos.

Se compone de dos tipos de elementos:

| Elemento | Nombre técnico | En Recicla Trujillo |
|---|---|---|
| Los objetos | **Vértices** (o nodos) | Puntos de acopio: "Centro", "La Esperanza", etc. |
| Las conexiones | **Aristas** (o bordes) | Rutas directas entre puntos |

**Analogía:** un mapa de distritos conectados por avenidas. Los distritos son vértices, las avenidas son aristas.

---

## 2. Terminología Fundamental

```
[La Esperanza] ——— [Florencia de Mora] ——— [El Porvenir]
      \                                          /
       \________________[Centro]_______________/
                            |
                      [Víctor Larco]
                            |
                         [Moche]
```

| Término | Definición | Ejemplo |
|---|---|---|
| **Vértice** | Un nodo del grafo | "Centro" |
| **Arista** | Conexión entre dos vértices | Centro — La Esperanza |
| **Grado** | Cuántas aristas tiene un vértice | "Centro" tiene grado 3 |
| **Vecinos** | Vértices directamente conectados | Vecinos de "Centro": La Esperanza, El Porvenir, Víctor Larco |
| **Camino** | Secuencia de vértices conectados | Centro → La Esperanza → Florencia de Mora |
| **Ciclo** | Camino que regresa al origen | Centro → La Esperanza → Florencia de Mora → El Porvenir → Centro |
| **Conectado** | Existe camino entre cualquier par | El grafo de acopio SÍ está conectado |

---

## 3. Grafos Dirigidos vs No Dirigidos

### Dirigido (Dígrafo)
Las aristas tienen **dirección**. A → B no implica B → A.

```
[A] ──→ [B] ──→ [C]
              ↑
         [D] ─┘
```
*Ejemplo: Twitter — seguir a alguien no significa que te sigan.*

### No Dirigido ← el que usamos
Las aristas son **bidireccionales**. Si A conecta con B, entonces B conecta con A.

```
[A] ──── [B] ──── [C]
              |
         [D] ─┘
```
*Ejemplo: Facebook — si eres amigo de alguien, ellos también son tus amigos.*

En nuestro caso: la ruta entre "Centro" y "La Esperanza" funciona en **ambos sentidos**, por eso es no dirigido.

---

## 4. Representación: Lista de Adyacencia con Nodos Propios

Hay dos formas clásicas de representar un grafo en memoria:

**Matriz de adyacencia** — usa `O(V²)` de memoria. Con 6 nodos, 36 celdas de las cuales la mayoría son cero. Ineficiente para grafos dispersos.

**Lista de adyacencia** — solo almacena las conexiones que existen: `O(V + E)` donde E = número de aristas.

Nosotros usamos lista de adyacencia, pero implementada **sin ninguna colección de la BCL**: una lista enlazada de nodos de adyacencia donde cada nodo guarda el vértice y una `NodeList<T>` propia con sus vecinos.

```
AdjacencyNode: [Centro | vecinos: La Esperanza → El Porvenir → Víctor Larco → null] → siguiente nodo
AdjacencyNode: [La Esperanza | vecinos: Centro → Florencia de Mora → null] → siguiente nodo
AdjacencyNode: [El Porvenir | vecinos: Centro → Florencia de Mora → null] → siguiente nodo
AdjacencyNode: [Florencia de Mora | vecinos: La Esperanza → El Porvenir → null] → siguiente nodo
AdjacencyNode: [Víctor Larco | vecinos: Centro → Moche → null] → siguiente nodo
AdjacencyNode: [Moche | vecinos: Víctor Larco → null] → null
```

La clase privada que sostiene esta estructura:

```csharp
private sealed class AdjacencyNode
{
    public T Vertex { get; }
    public NodeList<T> Neighbors { get; } = new();
    public AdjacencyNode? Next { get; set; }
    public AdjacencyNode(T vertex) => Vertex = vertex;
}
private AdjacencyNode? _head;
```

Cada `AdjacencyNode` apunta al siguiente vértice con `Next`, formando la lista de vértices. Dentro de cada uno, `Neighbors` es nuestra `NodeList<T>` enlazada con los vecinos.

---

## 5. Operaciones del Grafo

### Buscar un vértice — `Find` (privado)

Para cualquier operación necesitamos primero localizar el vértice recorriendo la lista:

```csharp
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
```

Complejidad: **O(V)** — recorre la lista de vértices uno por uno.

### Agregar vértice — `AddVertex`

```csharp
public void AddVertex(T vertex)
{
    if (Find(vertex) != null) return;
    _head = new AdjacencyNode(vertex) { Next = _head };
    _vertexCount++;
}
```

Se inserta al inicio de la lista (`_head`), operación O(1) una vez localizado que no existe.

### Agregar arista — `AddEdge`

```csharp
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
```

La clave es que se agrega en **ambos sentidos**: al agregar Centro — La Esperanza, la arista queda registrada tanto en los vecinos de Centro como en los de La Esperanza. Eso es lo que hace al grafo *no dirigido*.

### Consultar vecinos — `Neighbors`

```csharp
public T[] Neighbors(T vertex)
{
    var entry = Find(vertex);
    return entry == null ? new T[0] : ToArray(entry.Neighbors);
}
```

Devuelve un array. `ToArray` recorre la `NodeList<T>` de vecinos en dos pasadas: primero cuenta, luego llena el array.

```csharp
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
```

### Verificar si ya existe un vecino — `Contains` (privado)

```csharp
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
```

Recorre la lista nodo por nodo comparando con `.Equals()`. No hay `HashSet`, no hay `List.Contains`: búsqueda manual O(n).

---

## 6. Recorrido BFS (Breadth-First Search)

BFS = **búsqueda en anchura**. Explora el grafo nivel por nivel, como las ondas en el agua cuando cae una piedra.

### Por qué se necesita una Cola

BFS procesa los vértices **en el orden en que los descubre**. El primero que entra es el primero que se procesa (FIFO). Eso garantiza que siempre se exploren los nodos más cercanos antes que los lejanos.

```
Nivel 0:  Centro
Nivel 1:  La Esperanza, El Porvenir, Víctor Larco   ← vecinos de Centro
Nivel 2:  Florencia de Mora, Moche                  ← vecinos no visitados del nivel 1
```

### Implementación real en el proyecto

```csharp
public T[] BreadthFirstSearch(T origin)
{
    if (Find(origin) == null) return new T[0];

    var queue = new LinkedQueue<T>();      // cola propia FIFO — determina el orden de visita
    var marked = new NodeList<T>();        // lista propia — registra qué ya fue visitado
    var resultQueue = new LinkedQueue<T>(); // acumula el resultado en orden de visita

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
```

Tres estructuras propias trabajando juntas:
- `LinkedQueue<T>` como cola de procesamiento BFS
- `NodeList<T>` como registro de visitados (búsqueda lineal manual)
- `LinkedQueue<T>` como acumulador de resultado, convertido a `T[]` al final

### Traza de ejecución desde "Centro"

```
Estado inicial:
  Cola:     [Centro]
  Marcados: [Centro]

— Dequeue Centro →
  Resultado: [Centro]
  Vecinos: La Esperanza, El Porvenir, Víctor Larco (ninguno marcado → todos a la cola)
  Cola:     [La Esperanza, El Porvenir, Víctor Larco]
  Marcados: [Centro, La Esperanza, El Porvenir, Víctor Larco]

— Dequeue La Esperanza →
  Resultado: [Centro, La Esperanza]
  Vecinos: Centro (marcado), Florencia de Mora (nueva → enqueue)
  Cola:     [El Porvenir, Víctor Larco, Florencia de Mora]
  Marcados: [..., Florencia de Mora]

— Dequeue El Porvenir →
  Resultado: [Centro, La Esperanza, El Porvenir]
  Vecinos: Centro (marcado), Florencia de Mora (marcada)
  Cola:     [Víctor Larco, Florencia de Mora]

— Dequeue Víctor Larco →
  Resultado: [..., Víctor Larco]
  Vecinos: Centro (marcado), Moche (nuevo → enqueue)
  Cola:     [Florencia de Mora, Moche]
  Marcados: [..., Moche]

— Dequeue Florencia de Mora →
  Resultado: [..., Florencia de Mora]
  Vecinos: La Esperanza (marcada), El Porvenir (marcado)
  Cola:     [Moche]

— Dequeue Moche →
  Resultado: [..., Moche]
  Vecinos: Víctor Larco (marcado)
  Cola:     [] ← vacía, termina

Resultado final: [Centro, La Esperanza, El Porvenir, Víctor Larco, Florencia de Mora, Moche]
```

---

## 7. Geografía Real: Distritos de Trujillo

El grafo representa los distritos reales de la Provincia de Trujillo (Perú):

```
[Huanchaco]   [La Esperanza] ——— [Florencia de Mora] ——— [El Porvenir]
                    \                                          /
                     \______________ [Centro] _______________/    [Laredo]
                                        |
                                  [Víctor Larco]
                                        |
                                     [Moche]
                                        |
                                   [Salaverry]
```

El grafo del proyecto modela 6 de estos distritos con sus adyacencias reales:

| Arista en el grafo | ¿Es geográficamente correcta? |
|---|---|
| Centro — La Esperanza | ✅ La Esperanza está al noroeste de Trujillo centro |
| Centro — El Porvenir | ✅ El Porvenir limita al noreste con Trujillo centro |
| Centro — Víctor Larco | ✅ Víctor Larco limita al suroeste con Trujillo centro |
| La Esperanza — Florencia de Mora | ✅ Florencia de Mora está entre La Esperanza y El Porvenir |
| El Porvenir — Florencia de Mora | ✅ Florencia de Mora limita con El Porvenir al oeste |
| Víctor Larco — Moche | ✅ Moche está al sur de Víctor Larco |

> **Nota:** En la versión anterior del proyecto figuraba "Trujillo Norte" como vértice. Ese nombre no corresponde a ningún distrito oficial de la Provincia de Trujillo. Fue reemplazado por **Florencia de Mora**, que es el distrito real en esa posición geográfica.

---

## 8. El Módulo Puntos de Acopio en la App

El grafo se construye en `admin/Views/Acopio/AcopioView.cs` al iniciar la vista:

```csharp
private readonly UndirectedGraph<string> _network = new();

private void BuildNetwork()
{
    _network.AddEdge("Centro", "La Esperanza");
    _network.AddEdge("Centro", "El Porvenir");
    _network.AddEdge("Centro", "Víctor Larco");
    _network.AddEdge("La Esperanza", "Florencia de Mora");
    _network.AddEdge("El Porvenir", "Florencia de Mora");
    _network.AddEdge("Víctor Larco", "Moche");
}
```

Al seleccionar un punto de origen y presionar "Analizar":

```csharp
var neighbors = _network.Neighbors(origin);
var reachable  = _network.BreadthFirstSearch(origin);

lblOutput.Text =
    $"Vecinos directos: {(neighbors.Length > 0 ? string.Join(", ", neighbors) : "ninguno")}\r\n" +
    $"Alcanzables (BFS): {string.Join(" → ", reachable)}";
```

**Ejemplo con origen "La Esperanza":**
- Vecinos directos: `Centro, Florencia de Mora`
- Alcanzables (BFS): `La Esperanza → Centro → Florencia de Mora → El Porvenir → Víctor Larco → Moche`

El BFS muestra el orden en que un vehículo de recolección recorrería todos los puntos partiendo desde ese distrito, visitando siempre los más cercanos primero.

---

## 9. Complejidad Algorítmica

| Operación | Complejidad | Por qué |
|---|---|---|
| `AddVertex` | O(V) | `Find` recorre la lista de vértices |
| `AddEdge` | O(V) | Dos llamadas a `Find` |
| `Neighbors` | O(V + grado) | `Find` es O(V), luego `ToArray` es O(grado) |
| `BreadthFirstSearch` | **O(V² + E)** | Por cada vértice dequeued, `Contains` en marcados es O(V) |

> La implementación artesanal (sin `Dictionary` ni `HashSet`) tiene mayor complejidad que la versión con colecciones BCL (que sería O(V + E) para BFS). La ventaja es que **todo el manejo de memoria es explícito con nodos y punteros propios**, lo cual es el objetivo del curso.

---

## 10. ¿Por qué Grafo y no Árbol o Lista?

| Estructura | ¿Puede modelar la red de acopio? | Por qué |
|---|---|---|
| Lista enlazada | ❌ | Solo conexiones lineales: A→B→C→... sin bifurcaciones |
| Árbol | ❌ | Solo jerarquía padre→hijos, sin ciclos posibles |
| **Grafo** | ✅ | Conexiones arbitrarias, ciclos, múltiples rutas entre nodos |

El mapa de distritos tiene **ciclos**: puedes ir Centro → La Esperanza → Florencia de Mora → El Porvenir → Centro y volver al punto de partida. Un árbol no puede modelar eso porque en un árbol no existen ciclos por definición.

---

## 11. Resumen para la Exposición

> *"El módulo de Puntos de Acopio usa un Grafo No Dirigido para representar la red de distritos de la ciudad de Trujillo. Cada distrito es un vértice, y cada ruta entre ellos es una arista bidireccional. Internamente el grafo está implementado sin ninguna colección de la BCL: usamos una lista enlazada propia de nodos de adyacencia, y cada nodo contiene a su vez una NodeList<T> con sus vecinos. Al seleccionar un punto de origen, el sistema calcula los vecinos directos y el recorrido BFS. El BFS usa nuestra propia LinkedQueue<T> para procesar los nodos nivel por nivel, y una NodeList<T> para rastrear los visitados con búsqueda manual, garantizando que se exploren primero los distritos más cercanos antes que los más lejanos."*

---

## 12. Posibles preguntas del evaluador

**¿Por qué no usas `Dictionary` o `HashSet` de la BCL?**
> El objetivo del curso es manejar memoria a bajo nivel con nodos y punteros. `Dictionary` y `HashSet` son colecciones de alto nivel que ocultan esa gestión. Implementamos la misma funcionalidad con nuestra propia lista enlazada de `AdjacencyNode` y búsqueda manual con `while`.

**¿Qué sacrificas al no usar `HashSet` para los visitados?**
> La búsqueda de visitados pasa de O(1) a O(V). Para 6 nodos es irrelevante en la práctica, pero en un grafo grande sería costoso. Es el trade-off consciente de priorizar la implementación artesanal sobre la eficiencia.

**¿Qué pasaría si el grafo no estuviera conectado?**
> BFS solo alcanzaría el componente conectado al origen. Los vértices aislados no aparecerían en el resultado. En nuestro caso el grafo siempre está conectado porque las rutas están fijas.

**¿Por qué BFS y no DFS?**
> BFS explora por niveles (distancia creciente desde el origen), lo que es más natural para redes de distribución donde quieres saber "qué tan lejos está cada punto". DFS iría lo más profundo posible antes de retroceder, lo que no refleja bien la lógica de rutas geográficas.

**¿Cuánta memoria usa?**
> `O(V + E)` donde V=6 vértices y E=6 aristas: 6 `AdjacencyNode` más 12 nodos de vecinos en total (cada arista se guarda dos veces por ser bidireccional).

**¿"Florencia de Mora" es un distrito real de Trujillo?**
> Sí. Florencia de Mora es un distrito oficial de la Provincia de Trujillo que limita con La Esperanza al oeste y con El Porvenir al este, exactamente como está modelado en el grafo.
