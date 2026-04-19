# Guía de arquitectura para Controladores

## Objetivo

Los controladores son la puerta de entrada HTTP de la API. Su responsabilidad es recibir la solicitud, llamar al servicio correcto y transformar el resultado del servicio en una respuesta HTTP clara.

El controlador no debe contener la lógica del negocio.

---

## Responsabilidad principal

Un controlador debe:

- Recibir requests HTTP.
- Leer parámetros de ruta, body y query.
- Llamar a un servicio.
- Traducir resultados del servicio a respuestas HTTP.
- Mantener endpoints claros, simples y cortos.

---

## Qué NO debe hacer un controlador

Un controlador no debe:

- Calcular puntos.
- Validar reglas del negocio complejas.
- Modificar directamente varias entidades si eso pertenece al negocio.
- Tener lógica repetida entre endpoints.
- Consultar la base de datos directamente si ya existe un servicio para eso.

Ejemplo incorrecto:

- Buscar usuario, calcular puntos, crear entrega y actualizar saldo dentro del mismo endpoint.

Eso debe vivir en el servicio.

---

## Patrón de traducción de resultados

Para este proyecto se usará esta convención entre servicio y controlador:

- Lista → `200 OK`
- Recurso encontrado → `200 OK`
- Recurso no encontrado (`null`) → `404 NotFound`
- Creación exitosa → `201 CreatedAtAction`
- Actualización exitosa → `200 OK`
- Eliminación exitosa → `204 NoContent`
- Regla de negocio inválida (`InvalidOperationException`) → `400 BadRequest`

---

## Reglas de diseño

### 1. El controlador debe ser delgado

Un endpoint ideal tiene este flujo:

1. Recibe datos.
2. Llama al servicio.
3. Interpreta el resultado.
4. Devuelve la respuesta HTTP.

Si el endpoint empieza a crecer demasiado, seguramente estás metiendo lógica donde no va.

### 2. Un controlador trabaja con servicios, no con reglas

Bien:

```csharp
var result = await _deliveryService.RegisterDelivery(dto);
return CreatedAtAction(nameof(GetDelivery), new { id = result.Id }, result);
```

Mal:

```csharp
var user = await _context.Users.FindAsync(dto.UserId);
var points = dto.QuantityKg * 10;
user.Points += points;
```

### 3. Cada endpoint debe responder de forma predecible

El cliente debe poder saber fácilmente qué esperar.

Ejemplo:

- `GET /api/deliveries/5` devuelve `404` si no existe.
- `POST /api/deliveries` devuelve `400` si la operación es inválida.
- `DELETE /api/deliveries/5` devuelve `204` si se eliminó.

### 4. Capturar solo excepciones esperadas de negocio

Para este proyecto, el controlador puede capturar `InvalidOperationException` y traducirla a `400 BadRequest`.

No conviene capturar `Exception` general en todos los endpoints, porque eso puede ocultar errores reales durante desarrollo.

### 5. Usar tipos de retorno coherentes

Se recomienda:

- `Task<ActionResult<T>>` cuando el endpoint devuelve datos.
- `Task<IActionResult>` cuando solo devuelve códigos o resultados sin cuerpo fijo.

### 6. Mantener rutas consistentes

Ejemplo recomendado:

- `GET /api/deliveries`
- `GET /api/deliveries/{id}`
- `POST /api/deliveries`
- `PUT /api/deliveries/{id}`
- `DELETE /api/deliveries/{id}`

---

## Plantilla recomendada de endpoints

### Listar

```csharp
[HttpGet]
public async Task<ActionResult<IEnumerable<DeliveryDto>>> GetDeliveries()
{
    var result = await _deliveryService.ListDeliveries();
    return Ok(result);
}
```

### Obtener por id

```csharp
[HttpGet("{id}")]
public async Task<ActionResult<DeliveryDto>> GetDelivery(int id)
{
    var delivery = await _deliveryService.GetDeliveryById(id);
    if (delivery == null)
        return NotFound();

    return Ok(delivery);
}
```

### Crear

```csharp
[HttpPost]
public async Task<ActionResult<DeliveryDto>> Create(DeliveryCreateDto dto)
{
    try
    {
        var result = await _deliveryService.RegisterDelivery(dto);
        return CreatedAtAction(nameof(GetDelivery), new { id = result.Id }, result);
    }
    catch (InvalidOperationException ex)
    {
        return BadRequest(new { message = ex.Message });
    }
}
```

### Actualizar

```csharp
[HttpPut("{id}")]
public async Task<IActionResult> PutDelivery(int id, DeliveryUpdateDto dto)
{
    try
    {
        var updated = await _deliveryService.UpdateDelivery(id, dto);

        if (updated == null)
            return NotFound();

        return Ok(updated);
    }
    catch (InvalidOperationException ex)
    {
        return BadRequest(new { message = ex.Message });
    }
}
```

### Eliminar

```csharp
[HttpDelete("{id}")]
public async Task<IActionResult> DeleteDelivery(int id)
{
    var deleted = await _deliveryService.DeleteDelivery(id);
    if (!deleted)
        return NotFound();

    return NoContent();
}
```

---

## Convenciones para este proyecto

### Sobre DTOs

Los controladores deben recibir y devolver DTOs, no exponer entidades directamente.

Esto ayuda a:

- controlar qué campos entran y salen
- evitar exponer detalles internos
- mantener la API estable

### Sobre validación

La validación básica de formato y requeridos debe vivir en los DTOs.

Ejemplos:

- campos obligatorios
- rangos mínimos
- longitud de texto

La validación de negocio debe vivir en el servicio.

Ejemplos:

- usuario inexistente
- stock insuficiente
- puntos insuficientes

### Sobre consistencia

Si un controlador captura `InvalidOperationException` en `POST`, debe seguir el mismo criterio en `PUT` cuando aplique.

La API debe sentirse uniforme.

---

## Señales de que un controlador está mal diseñado

- Tiene demasiadas líneas de lógica.
- Usa `AppDbContext` directamente para hacer reglas de negocio.
- Repite el mismo `try/catch` con mucha lógica adentro.
- Calcula valores del dominio en el endpoint.
- Devuelve respuestas inconsistentes entre endpoints similares.

---

## Regla de oro

El controlador traduce HTTP.

El servicio decide el negocio.
