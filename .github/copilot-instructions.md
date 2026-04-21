# Copilot Instructions

## General Guidelines
- The user prefers simpler configuration with a single source of truth for API BaseUrl (appsettings) and wants to avoid environment-variable override complexity.

## Project-Specific Rules
- En este repositorio, seguir el patrón del módulo Deliveries para nuevos módulos: no usar List<> ni Array[] para renderizar tablas o SelectMenus; transformar datos de API a NodeList<>; reutilizar los Components existentes; separar vistas de listado y vistas de formularios en carpetas por módulo con el flujo correspondiente.
- Para las vistas MAUI del proyecto app, usar DynamicResource para colores (evitar colores hardcodeados) y mantener los Entry simples sin envolverlos en Border.