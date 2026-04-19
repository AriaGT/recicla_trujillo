# Guía de arquitectura para Servicios

## Objetivo

Los servicios contienen la lógica del negocio. Un servicio debe encargarse de decidir **qué reglas aplicar**, **qué validar** y **qué operaciones ejecutar** sobre la base de datos o sobre otras dependencias.

El servicio no debe preocuparse por HTTP, rutas, códigos de respuesta ni detalles de la capa visual.

---

## Responsabilidad principal

Un servicio debe:

- Ejecutar casos de uso del sistema.
- Aplicar reglas de negocio.
- Coordinar acceso a datos.
- Transformar entidades a DTO cuando sea conveniente.
- Mantener un flujo claro y predecible.

Ejemplos en este proyecto:

- Registrar una entrega.
- Calcular puntos por tipo de residuo.
- Sumar puntos a un usuario.
- Canjear un producto.
- Descontar stock.

---

## Qué NO debe hacer un servicio

Un servicio no debe:

- Retornar `Ok()`, `NotFound()`, `BadRequest()` ni otros resultados HTTP.
- Conocer rutas, headers, query params o detalles de ASP.NET.
- Tener lógica de interfaz.
- Mezclar demasiadas responsabilidades en un solo método.
- Repetir código de mapeo muchas veces si puede centralizarse.

---

## Patrón de resultados para este proyecto

Para mantener el código simple y consistente, se usará esta convención:

- Métodos de listado devuelven listas.
- Métodos de búsqueda por id devuelven `null` si no existe.
- Métodos de creación lanzan `InvalidOperationException` cuando una regla de negocio no se cumple.
- Métodos de actualización devuelven `null` si el recurso no existe y lanzan `InvalidOperationException` si la regla de negocio es inválida.
- Métodos de eliminación devuelven `bool`.

### Ejemplo de criterio

- `GetById(id)` → `DeliveryDto?`
- `Create(dto)` → `DeliveryDto`
- `Update(id, dto)` → `DeliveryDto?`
- `Delete(id)` → `bool`

---

## Reglas de diseño

### 1. Un servicio debe hablar en términos del dominio

Los nombres deben expresar acciones del negocio.

Bien:

- `RegisterDelivery`
- `RedeemReward`
- `CalculatePoints`

Evitar:

- `DoStuff`
- `HandleData`
- `ProcessThing`

### 2. El servicio debe ser el dueño de la lógica

Si una regla modifica puntos, stock o relaciones, esa regla vive en el servicio.

Ejemplo:

- Al registrar una entrega, el servicio calcula los puntos y los suma al usuario.
- Al eliminar una entrega, el servicio descuenta los puntos otorgados antes.

### 3. Los servicios deben ser pequeños y enfocados

Un servicio puede tener varias operaciones, pero todas deben pertenecer al mismo contexto.

Por ejemplo:

- `DeliveryService` se encarga de entregas.
- `RedemptionService` se encarga de canjes.
- `AuthService` se encarga de autenticación.

### 4. Validar primero, modificar después

El flujo recomendado dentro de un método es:

1. Buscar entidades necesarias.
2. Validar reglas.
3. Calcular cambios.
4. Guardar cambios.
5. Retornar resultado.

### 5. Evitar lógica duplicada

Si un mapeo de entidad a DTO se repite, crear un método privado para eso.

Ejemplo:

```csharp
private static DeliveryDto ToDto(Delivery d) =>
    new(d.Id, d.UserId, d.WasteType, d.QuantityKg, d.PointsEarned, d.CreatedAt);
```

### 6. No usar `throw` para todo

Usar `throw` solo cuando la regla de negocio se rompe o cuando realmente se trata de una situación inválida.

Ejemplos válidos:

- Usuario no encontrado al registrar una entrega.
- Puntos insuficientes en un canje.
- Stock insuficiente.

Ejemplos donde no conviene lanzar excepción:

- `GetById` no encontró el registro.
- `Delete` sobre un id inexistente.

### 7. Mantener métodos predecibles

Cada método debe tener un comportamiento fácil de recordar.

Ejemplo:

- Si `UpdateDelivery` no encuentra la entrega, devuelve `null`.
- Si encuentra la entrega pero el usuario asociado no existe, lanza `InvalidOperationException`.

---

## Estructura recomendada de un método de servicio

```csharp
public async Task<DeliveryDto?> UpdateDelivery(int id, DeliveryUpdateDto dto)
{
    var delivery = await _context.Deliveries.FindAsync(id);
    if (delivery == null)
        return null;

    var user = await _context.Users.FindAsync(delivery.UserId);
    if (user == null)
        throw new InvalidOperationException("Usuario no encontrado");

    var previousPoints = delivery.PointsEarned;
    var newPoints = CalculatePoints(dto.WasteType, dto.QuantityKg);

    delivery.WasteType = dto.WasteType;
    delivery.QuantityKg = dto.QuantityKg;
    delivery.PointsEarned = newPoints;

    user.Points += (newPoints - previousPoints);

    await _context.SaveChangesAsync();

    return ToDto(delivery);
}
```

---

## Dependencias permitidas

Un servicio puede depender de:

- `AppDbContext`
- otros servicios del dominio si tiene sentido
- utilidades puras de negocio

Un servicio no debe depender de:

- controles de interfaz
- formularios
- clases de WinForms o MAUI
- `ControllerBase`

---

## Convenciones para este proyecto

### DeliveryService

Debe encargarse de:

- listar entregas
- obtener entrega por id
- registrar entrega
- actualizar entrega
- eliminar entrega
- calcular y ajustar puntos del usuario

### RedemptionService

Debe encargarse de:

- listar canjes
- registrar canje
- validar puntos disponibles
- validar stock
- descontar puntos y stock

### AuthService

Debe encargarse de:

- login por DNI para usuario
- login por credenciales para encargado
- devolver datos mínimos de sesión

---

## Regla de oro

Si una decisión cambia el estado del negocio, probablemente debe vivir en un servicio.

Si solo responde HTTP, probablemente pertenece al controlador.
