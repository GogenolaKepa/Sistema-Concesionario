# 🚗 Sistema de Gestión de Concesionaria

Este proyecto fue desarrollado como trabajo final integrador de la carrera **Ingeniería en Sistemas Informáticos** para el 3° año con titulo de **Analista en Sistemas**. Consiste en el desarrollo de un sistema de escritorio completo para la **gestión integral de una concesionaria de vehículos**, incluyendo funcionalidades de stock, ventas, seguridad, usuarios, proveedores, auditorías y más.

---

## 📌 Tecnologías Utilizadas

- **Lenguaje:** C# (.NET 7)
- **Base de datos:** SQL Server 2022
- **ORM:** Entity Framework Core 7 (con migraciones)
- **Interfaz gráfica:** Windows Forms (WinForms)
- **Control de versiones:** Git + GitHub

### 📦 Librerías externas

- `BCrypt.Net-Next` → Hashing seguro de contraseñas
- `iTextSharp` → Generación de PDFs
- `System.Configuration` → Manejo de cadena de conexión
- `System.Data.SqlClient` → Operaciones directas en BD

---

## 🧩 Arquitectura General del Proyecto

El sistema está basado en una **arquitectura por capas**, con separación clara entre lógica de negocio, acceso a datos, y presentación. Se organizaron los componentes en las siguientes carpetas principales:

### 1. 🧠 Modelo

Contiene la lógica de negocio, entidades y validaciones.

- `Cliente.cs`, `Empleado.cs`, `Vehiculo.cs`
- `Producto.cs`, `ProductoPerecedero.cs`, `ProductoNoPerecedero.cs`
- `Grupo.cs`, `Usuario.cs`, `Auditoria.cs`, `ItemVenta.cs`

> 🧠 **Patrones aplicados**:
> - `Strategy`: Productos perecederos/no perecederos implementan distintas estrategias de validación.
> - `Composite`: En productos agrupados o estructuras jerárquicas (si aplica).
> - `Observer`: Para auditoría de eventos (como login/logout) y logs del sistema.

---

### 2. 🗂 Controladoras

Encargadas de orquestar las operaciones entre la UI y la base de datos.

- `ControladoraGeneral.cs`: orquestador principal
- `ControladoraUsuarios.cs`, `ControladoraVentas.cs`, `ControladoraStock.cs`
- `ControladoraSeguridad.cs`, `ControladoraAuditoria.cs`

---

### 3. 🧾 Formularios (UI)

Construidos con Windows Forms. Cada funcionalidad principal cuenta con su propio formulario:

- `FormLogin.cs`: Login e inicio de sesión
- `FormMenuPrincipal.cs`: Menú principal del sistema
- `FormVentas.cs`, `FormClientes.cs`, `FormInventario.cs`
- `FormAuditoria.cs`, `FormConfiguracion.cs`, etc.

---

### 4. 🔐 Módulo de Seguridad

Contiene toda la lógica relacionada a la autenticación y autorización:

- Permite login seguro con hashing
- Gestión de usuarios y grupos con distintos permisos
- Auditoría automática de eventos como login, logout y acciones sensibles

---

### 5. 📝 Auditoría y Logs

Sistema propio que registra:

- Inicio y cierre de sesión de cada usuario
- Acciones importantes (modificaciones, eliminaciones, etc.)
- Errores y eventos críticos

Los registros se almacenan directamente en la base de datos.

---

## 🧪 Base de Datos

No incluye archivo `.sql` con:

- Script de creación de tablas y relaciones
- Inserción de datos de ejemplo
- Control de integridad referencial

---

## 📂 Estructura del Proyecto

```
├── /Modelo/
│   ├── Entidades/
├── /Controladoras/
├── /Modulo_de_Seguridad/
├── /Vista/
│   ├── FormLogin.cs
│   ├── FormVentas.cs
│   ├── FormMenuPrincipal.cs
│   ├── FormClientes.cs
│   └── FormInventario.cs
├── /SQL/
│   └── TrabajoDeDiploma.sql
├── /Documentacion/
│   ├── Trabajo de Diploma.docx
│   └── Entrega #2 Parcial.mdj
```

---

## 🏗️ Patrones de Diseño Usados

- **Strategy** → validaciones y comportamientos de productos
- **Observer** → auditoría de eventos
- **Composite** → jerarquía de productos (si se aplica)
- **Repository (implícito)** → gestión de entidades con EF Core
- **Singleton** → patrón aplicado a la controladora general (acceso global controlado)

---

## 📄 Documentación y Anexos

Algunas secciones complementarias como manuales de usuario, documentación técnica detallada o anexos del sistema no han sido adjuntadas en este repositorio por motivos de espacio y/o confidencialidad, pero pueden ser provistas a pedido.

---

## 🚀 Instrucciones de Ejecución

1. Clonar el repositorio
2. Restaurar los paquetes NuGet
3. Ejecutar migraciones (`Update-Database`) o usar el script `TrabajoDeDiploma.sql`
4. Configurar cadena de conexión en `app.config`
5. Compilar y ejecutar desde `FormLogin.cs`

---

## 👤 Autor

> **Kepa Gogenola**  
> Proyecto final para Analista en Sistemas.  
> Universidad Abierta Interamericana – Ingeniería en Sistemas
