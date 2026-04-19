# Arquitectura Fusionada del Proyecto (.NET 10)

Este documento define reglas estrictas para mantener una arquitectura simple, mantenible y sin sobreingeniería.

---

## 1. Estructura oficial de la solución

```text
📁 recicla_trujillo.sln
├── 📁 api
│   └── 📄 api.csproj                 # API REST principal (ASP.NET Core)
├── 📁 shared
│   └── 📄 shared.csproj              # Contratos + cliente HTTP reusable
└── 📁 admin
    └── 📄 admin.csproj               # Cliente WinForms de administración
```

No se deben crear capas/proyectos adicionales sin una necesidad técnica real.

---

## 2. Reglas estrictas por proyecto

### 2.1 `api`
**Debe:**
- Exponer endpoints HTTP.
- Mantener controladores delgados (HTTP in/out).
- Concentrar reglas de negocio en servicios.
- Consumir contratos desde `shared`.

**No debe:**
- Duplicar DTOs/enums ya existentes en `shared`.
- Mover lógica de negocio a controladores.

---

### 2.2 `shared`
**Debe:**
- Ser la única fuente de verdad de contratos compartidos (DTOs/enums).
- Contener el cliente HTTP reutilizable (`ApiClient`).
- Organizar DTOs por archivo en `shared/DTOs`:
  - `AuthDtos.cs`
  - `UserDtos.cs`
  - `RewardDtos.cs`
  - `DeliveryDtos.cs`
  - `RedemptionDtos.cs`

**No debe:**
- Contener lógica de UI.
- Contener lógica de negocio del backend.

---

### 2.3 `admin`
**Debe:**
- Contener solo lógica de presentación y flujo UI.
- Consumir `ApiClient` vía inyección de dependencias.
- Leer configuración local desde `appsettings.json`.

**No debe:**
- Construir `HttpClient` manualmente en formularios.
- Pedir la URL de API al usuario en la UI.
- Duplicar contratos ya definidos en `shared`.

---

## 3. Configuración de BaseUrl (regla anti-sobreingeniería)

### Regla única (obligatoria)
La URL base de la API en clientes WinForms se configura **solo** en:
- `appsettings.json` del cliente
- clave: `ApiSettings:BaseUrl`

Ejemplo:

```json
{
  "ApiSettings": {
    "BaseUrl": "https://localhost:7035/"
  }
}
```

### Reglas explícitas
- **Sí permitido:** leer `ApiSettings:BaseUrl` con `IOptions<ApiSettings>`.
- **No permitido:** múltiples fuentes de verdad para `BaseUrl`.
- **No permitido:** overrides por variables de entorno para `BaseUrl` en este proyecto.
- **No permitido:** seleccionar `BaseUrl` desde controles UI.

Objetivo: predictibilidad, simplicidad y menor costo de mantenimiento.

---

## 4. Contratos compartidos

- Todo contrato API compartido vive en `shared`.
- Si cambia un contrato, se modifica en `shared` y se propaga a consumidores.
- `UserRole` en `shared` es la única fuente de verdad para roles (`Citizen`, `Admin`).

---

## 5. Cliente HTTP centralizado

- `ApiClient` encapsula rutas, serialización y manejo básico de errores de negocio.
- Los formularios no deben conocer detalles de endpoints.
- Si se agrega endpoint en `api`, se agrega método equivalente en `ApiClient`.

---

## 6. Criterio para nuevos cambios (gate de complejidad)

Antes de agregar configuración, capas o abstracciones nuevas, validar:
1. ¿Resuelve un problema real hoy?
2. ¿Reduce complejidad neta?
3. ¿Evita duplicación sin introducir flujo difícil de entender?

Si alguna respuesta es “no”, **no se implementa**.

---

## 7. Resumen operativo

1. Contratos compartidos en `shared/DTOs/*`.
2. Integración HTTP en `shared/ApiClient.cs`.
3. UI en `admin`.
4. BaseUrl en `admin/appsettings.json` como única fuente.
5. Evitar sobreingeniería por norma.