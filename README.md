🚗 Sistema de Gestión de Concesionaria

Este proyecto es el final de Analista en Sistemas y consiste en el desarrollo de un sistema integral para la gestión de una concesionaria de vehículos. Permite administrar stock, ventas, auditorías, usuarios, proveedores, y más.

🧰 Tecnologías utilizadas

Lenguaje: C# (.NET 7)

Base de datos: SQL Server 2022

ORM: Entity Framework Core 7 (con migraciones)

Interfaz gráfica: Windows Forms

Librerías externas:

BCrypt.Net-Next para hashing de contraseñas

iTextSharp para generación de PDFs

Auditoría y Logs: Módulo propio + registros en base de datos

Persistencia: Contexto EF Concesionario.cs

Control de versiones: Git + GitHub

🗂️ Estructura del proyecto
├── Vista/                         # Proyecto de Windows Forms (presentación)
│   ├── FormLogin.cs              # Inicio de sesión
│   ├── FormMenuPrincipal.cs      # Pantalla principal
│   ├── FormVentas.cs             # Gestión de ventas
│   ├── FormClientes.cs           # ABM clientes
│   ├── FormInventario.cs         # Gestión de vehículos en stock
│   └── Modulo_de_Seguridad/     # Módulo de seguridad (login, auditoría)
│
├── Modelo/                       # Proyecto de acceso a datos (EF Core)
│   ├── Concesionario.cs          # DbContext
│   └── Entidades/               # Entidades de negocio
│       ├── Vehiculo.cs
│       ├── Inventario.cs
│       ├── Usuario.cs
│       ├── Grupo.cs
│       ├── Auditoria.cs
│       └── ...
│
├── SQL/
│   └── TrabajoDeDiploma.sql     # Script de creación de base de datos
│
├── Documentacion/
│   ├── Trabajo de Diploma.docx   # Documento técnico con análisis completo
│   └── Entrega #2 Parcial.mdj    # Diagrama de clases y casos de uso (StarUML)

🔐 Módulo de Seguridad

Incluye funcionalidades de inicio y cierre de sesión, auditoría, y permisos basados en grupos.

Inicio de sesión con verificación de contraseña (BCrypt)

Auditoría en tabla Auditorias:

Registro de inicio de sesión

Registro de logout

Acciones críticas del sistema

Gestión de permisos a través de Grupos y Permisos

Vista de auditoría con filtro por fecha y tipo de acción

🧱 Base de datos
Tablas principales:

Vehiculos: datos de cada modelo, precio, disponibilidad

Inventarios: stock físico por vehículo

Proveedores: marcas o distribuidores

Clientes: compradores del sistema

Ventas: historial de operaciones

Usuarios: login del sistema

Grupos, Permisos, UsuarioGrupo: control de roles

Auditorias: acciones del sistema

👉 Todas las relaciones están integradas con Foreign Keys. La sincronización entre Vehiculos e Inventarios se da por el VehiculoId.

🧠 Patrones de Diseño Utilizados
✅ Observer

Aplicado en el módulo de seguridad: la clase GestorAuditoria notifica automáticamente a los observadores cuando hay inicio/cierre de sesión o eventos relevantes.

Cada acción genera un registro en la tabla Auditorias.

✅ Strategy

Implementado en el módulo de Backup (si lo activás): permite cambiar dinámicamente el método de backup (local, externo, zip, etc.) sin modificar el código del módulo de ejecución.

✅ Composite

Utilizado en el sistema de permisos. Un grupo puede tener múltiples permisos y a su vez pertenecer a estructuras jerárquicas, permitiendo representar comportamientos compuestos.

📋 Funcionalidades destacadas

🔐 Login seguro con hash

📈 Reportes PDF (ventas, stock, auditorías)

🧾 ABM completo de:

Vehículos

Clientes

Proveedores

Usuarios y Grupos

🛠️ Auditoría en tiempo real

🔄 Backup de base de datos

🧮 Control de stock sincronizado

🧪 Consideraciones técnicas

Se recomienda tener SQL Server 2022 instalado

La cadena de conexión en appsettings.json o en el constructor del DbContext está configurada para uso local (localhost)

Compatible con Visual Studio 2022 (.NET 7)

Se recomienda correr las migraciones EF Core antes de la primera ejecución

▶️ Cómo ejecutar el proyecto

Clonar el repositorio:

git clone https://github.com/tuusuario/concesionaria.git


Configurar cadena de conexión en Concesionario.cs o app.config:

optionsBuilder.UseSqlServer("Server=localhost;Database=ConcesionarioDB;Trusted_Connection=True;");


Ejecutar migraciones (opcional):

dotnet ef database update


Iniciar el proyecto desde Visual Studio (Vista/FormLogin.cs)

Algunas secciones complementarias como manuales de usuario, documentación técnica detallada o anexos del sistema no han sido adjuntadas en este repositorio por motivos de espacio y/o confidencialidad.

👤 Autor

Kepa Gogenola
Proyecto final para Analista en Sistemas. ISI - UAI Rosario
