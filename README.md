#  API para la Gestión de Cursos (ApiGestionCursos)

¡Bienvenido al backend de **Gestión de Cursos**! Esta es una API REST profesional, robusta y con un diseño moderno por capas construida sobre **ASP.NET Core** utilizando **.NET 8.0**. El proyecto implementa una arquitectura desacoplada y escalable que cuenta con seguridad por roles a través de JWT, persistencia de datos mediante Entity Framework Core y versionamiento de endpoints.

---

##  Descripción del Proyecto

Esta API funciona como el motor principal de una plataforma académica para administrar el ciclo de vida de capacitaciones, cursos y asignaturas. Su enfoque principal es proveer endpoints seguros y eficientes para gestionar de manera relacional las operaciones del negocio escolar o empresarial.

El sistema organiza y mapea sus funcionalidades sobre un modelo de dominio compuesto por:
* **Cursos (`Curso` y `CursoController`):** Planificación, estructuración y catálogo de las asignaturas ofertadas.
* **Categorías (`Categoria` y `CategoriaController`):** Taxonomía y agrupamiento de asignaturas para búsquedas segmentadas.
* **Docentes (`Docente` y `DocenteController`):** Administración del equipo de instructores y profesores encargados de los módulos.
* **Estudiantes (`Estudiante` y `EstudianteController`):** Registro, control de alumnos y seguimiento del alumnado.
* **Inscripciones (`Inscripcion`):** Entidad relacional encargada de gestionar los accesos e interacciones de estudiantes dentro de cada curso.
* **Usuarios y Seguridad (`ApplicationUser`, `User` y `UsersController`):** Autenticación y control de accesos centralizado, asignando permisos basados en Roles del sistema (ej. `Admin`).

---

##  Características Principales

* **Arquitectura Limpia en .NET 8:** Separación estricta de responsabilidades mediante controladores desacoplados, abstracción por repositorios y entidades independientes.
* **Autenticación e Identity:** Implementación de **ASP.NET Core Identity** combinado con tokens **JWT (JSON Web Tokens)** para una seguridad basada en roles (Role-Based Authorization).
* **Mapeo de Alta Velocidad:** Uso de **Mapster** para la transformación ágil y optimizada de Entidades hacia Objetos de Transferencia de Datos (DTOs).
* **Persistencia Relacional (ORM):** Acceso a datos gestionado por **Entity Framework Core (EF Core)** bajo el enfoque *Code-First*, integrando **SQL Server** como motor de base de datos primario.
* **Versionamiento de API:** Control y evolución de contratos HTTP mediante **Asp.Versioning.Mvc**, permitiendo estructurar rutas semánticas como `api/v{version}/[controller]`.
* **Documentación Dinámica:** Generación automatizada de esquemas y pruebas interactivas de endpoints a través de **Swagger (Swashbuckle.AspNetCore)**.

---

##  Stack Tecnológico & Paquetes Usados

* **Framework Base:** ASP.NET Core Web API (`net8.0`)
* **ORM & Base de Datos:** Microsoft.EntityFrameworkCore.SqlServer (v8.0.17)
* **Seguridad & Cifrado:** Identity EF Core, Authentication JwtBearer (v8.0.17) y BCrypt.Net-Next
* **Mapeo de Objetos:** Mapster & Mapster.DependencyInjection (v10.0.7)
* **Versionamiento:** Asp.Versioning.Mvc & ApiExplorer (v8.1.0)
* **Documentación:** Swashbuckle.AspNetCore (v6.4.0)

---
<img width="681" height="566" alt="aaaaaa" src="https://github.com/user-attachments/assets/b8723882-3a07-4d85-9d0b-9ab260a68b61" />

##  Estructura del Directorio

El diseño del explorador de soluciones refleja una organización limpia y estandarizada en el desarrollo corporativo de .NET:

```text
ApiGestionCursos/
├── Constants/          # Definición de constantes del sistema (Roles, políticas, etc.)
├── Controllers/        # Controladores REST (CursoController, DocenteController, EstudianteController, UsersController)
├── Migrations/         # Historial de migraciones automáticas generadas por EF Core Code-First
├── Models/             # Entidades de negocio y estructura de datos
│   └── Dtos/           # Objetos de Transferencia de Datos (DTOs) para requests/responses seguros
├── Properties/         # Configuración del entorno de ejecución (launchSettings.json)
├── Repository/         # Abstracción de acceso a datos e interfaces de repositorio (IUserRepository, etc.)
├── Services/           # Servicios con lógica de negocio desacoplada de los controladores
├── data/               # Contexto de base de datos (ApplicationDbContext.cs)
├── Mapping/            # Configuraciones y perfiles para el mapeo de objetos
├── Program.cs          # Punto de entrada de la aplicación, contenedor de DI y configuración del Pipeline HTTP
├── appsettings.json    # Cadenas de conexión y llaves de configuración global de la app
└── ApiGestionCursos.csproj # Archivo de configuración del proyecto de .NET y dependencias Nuget
