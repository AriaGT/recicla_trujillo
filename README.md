# ♻️ Recicla Trujillo - Plataforma de Economía Circular

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-Neon-4169E1?logo=postgresql)
![Azure](https://img.shields.io/badge/Azure-App%20Service-0089D6?logo=microsoft-azure)
![MAUI](https://img.shields.io/badge/.NET-MAUI-512BD4?logo=dotnet)

## 📖 Sobre el Proyecto

"Recicla Trujillo" es una plataforma integral enfocada en solucionar la problemática de la mala gestión de residuos sólidos urbanos en zonas específicas de la ciudad. El sistema incentiva a los ciudadanos a realizar actividades de reciclaje y segregación de residuos mediante un modelo de **economía circular monetaria**: al entregar residuos el ciudadano recibe un pago (egreso de caja) y puede adquirir recompensas pagando su precio (ingreso de caja).

### 💰 Módulo de Caja (Ingresos / Egresos)

El estado financiero se maneja con **saldo derivado** (sin tabla de caja dedicada):

- **Egresos:** cada **Entrega** de residuos paga un monto monetario al ciudadano (tarifa S//kg según el tipo de residuo).
- **Ingresos:** cada **Venta** relaciona un usuario con una recompensa por su precio en soles, descontando stock y generando un código de retiro.
- **Saldo:** `Σ ventas (ingresos) − Σ entregas (egresos)`, calculado al vuelo por el `CashService`.

## 🚀 Arquitectura y Stack Tecnológico

El ecosistema está construido bajo una arquitectura distribuida orientada a servicios utilizando **.NET 10**.

- **Backend API:** ASP.NET Core API (.NET 10) que centraliza las transacciones monetarias (ingresos/egresos), las ventas y la validación del inventario. Documentación autogenerada con **Scalar**.
- **Base de Datos:** Relacional, utilizando **PostgreSQL** desplegada en la plataforma **Neon**.
- **ORM:** Entity Framework Core para la migración y manipulación de entidades.
- **Frontend Administrador:** Aplicación de escritorio construida en **Windows Forms (WinForms)** para el registro en puntos de acopio y validación física de residuos.
- **Frontend Ciudadano:** Aplicación móvil nativa (Android/iOS) desarrollada con **.NET MAUI**.
- **Capa Transversal (Shared):** Proyecto `.NET Class Library` utilizado para compartir DTOs, Enums, lógica de negocio y métodos del API Client, garantizando la cohesión absoluta entre todos los proyectos de la solución.

## 🧠 Estructuras de Datos Personalizadas (Memoria Dinámica)

Como requerimiento técnico central del proyecto, el manejo del estado en memoria en los clientes frontend (MAUI y WinForms) **no utiliza** las colecciones genéricas de alto nivel provistas por el framework (como `List<T>` o `ObservableCollection<T>`).

- Se implementó una arquitectura basada en **Listas Simplemente Enlazadas (Nodos y Punteros)**.
- Se diseñaron las clases genéricas base `Node<T>` y `NodeList<T>` dentro de la librería compartida para almacenar temporalmente los DTOs que provienen de las peticiones a la API.
- **Rendimiento:** Esta estructura garantiza un tiempo algorítmico de inserción de **$O(1)$** al agregar elementos al inicio, optimizando significativamente la carga, deserialización masiva y renderizado de historiales recientes y catálogos de recompensas.

### Estructuras adicionales y sus usos

Todas son genéricas y viven en `shared/Structures/`:

| Estructura | Clase | Uso real en la app |
|------------|-------|--------------------|
| **Pila** (LIFO) | `LinkedStack<T>` | Vista de **Caja** (admin): apila los movimientos para mostrar primero los más recientes. |
| **Cola** (FIFO) | `LinkedQueue<T>` | Vista de **Ventas** (admin): cola de ventas pendientes de entrega; el botón "Atender siguiente" hace `Dequeue`. |
| **Árbol Binario de Búsqueda** | `BinarySearchTree<T>` | Vista de **Usuarios** (admin): búsqueda de usuarios por DNI, reportando el nº de comparaciones. |
| **Grafo no dirigido** | `UndirectedGraph<T>` | Vista de **Puntos de Acopio** (admin): red de puntos y rutas; calcula vecinos y recorrido **BFS** (usa internamente `LinkedQueue<T>`). |

> Nota: las clases usan nombres estándar en inglés (`LinkedStack`/`LinkedQueue` en vez de `Stack`/`Queue`) para evitar colisión con `System.Collections.Generic.Stack<T>`/`Queue<T>`, ya que todos los proyectos tienen `ImplicitUsings` habilitado.

## ⚙️ Módulos del Sistema

1. **API RESTful:** Motor central con despliegue Cloud-Native encargado de la lógica de negocio (entregas, ventas y caja).
2. **App WinForms (Administradores):** Permite al personal autorizado registrar entregas de residuos pagando al ciudadano (egreso), gestionar recompensas y ventas, validar códigos de retiro y consultar el reporte de caja y la red de puntos de acopio.
3. **App .NET MAUI (Ciudadanos):** Interfaz interactiva para explorar el catálogo de recompensas con sus precios y comprarlas (generando una venta) directamente desde el dispositivo móvil.

## ☁️ Despliegue

- **Backend API:** Desplegado en la nube utilizando **Azure App Service**, asegurando alta disponibilidad para el consumo concurrente de los clientes.
- **Base de Datos:** Entorno Cloud Serverless en **Neon (PostgreSQL)**.

---

_Proyecto académico desarrollado para el curso de Estructura de Datos - Universidad Privada del Norte (Sede Trujillo, Perú)._
