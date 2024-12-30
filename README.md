# Documentación Técnica - Sistema de Gestión de Ventas

## Solución: "SalesManagementSystem"
La solución está estructurada bajo el patrón de arquitectura en tres capas (UI, BLL, DAL) con Visual Studio 2019, utilizando Visual Basic y SQL Server 2008 como base de datos. Se implementa sobre .NET Framework 4.8.

## Proyecto: PRUEBADEMO.DAL
El proyecto "PRUEBADEMO.DAL" es una biblioteca de clases (.NET Framework) que encapsula la lógica de acceso a datos. Su propósito principal es interactuar con la base de datos mediante consultas SQL para operaciones CRUD y generación de informes.

### Namespace y Ensamblado
- Nombre del ensamblado: `PRUEBADEMO.DAL`
- Namespace raíz: `PRUEBADEMO.DAL`

### Componentes
1. **DatabaseHelper**
   - **Descripción**: Módulo que centraliza la conexión a la base de datos.
   - **Método principal**:
     - `GetConnection()`: Devuelve una instancia de `SqlConnection` utilizando la cadena de conexión configurada en el archivo de configuración.

2. **ClienteDAL**
   - **Descripción**: Gestiona operaciones relacionadas con la tabla clientes.
   - **Métodos principales**:
     - `GetAllClientes()`: Retorna todos los registros de la tabla clientes.
     - `InsertCliente(nombre As String, telefono As String, correo As String)`: Inserta un nuevo cliente.
     - `UpdateCliente(id As Integer, nombre As String, telefono As String, correo As String)`: Actualiza un cliente existente.
     - `DeleteCliente(id As Integer)`: Elimina un cliente por su ID.
     - `SearchClientesByName(name As String)`: Busca clientes cuyo nombre contenga un texto específico.

3. **ProductoDAL**
   - **Descripción**: Gestiona operaciones relacionadas con la tabla productos.
   - **Métodos principales**:
     - `GetAllProductos()`: Retorna todos los registros de la tabla productos.
     - `InsertProducto(nombre As String, precio As Decimal, categoria As String)`: Inserta un nuevo producto.
     - `UpdateProducto(id As Integer, nombre As String, precio As Decimal, categoria As String)`: Actualiza un producto existente.
     - `DeleteProducto(id As Integer)`: Elimina un producto por su ID.
     - `SearchProductosByName(name As String)`: Busca productos cuyo nombre contenga un texto específico.
     - `GetProductReport()`: Genera un informe de ventas por producto agrupado por mes.

4. **VentaDAL**
   - **Descripción**: Gestiona operaciones relacionadas con la tabla ventas y sus elementos.
   - **Métodos principales**:
     - `GetAllVentas()`: Retorna todas las ventas registradas.
     - `InsertVenta(clienteID As Integer, fecha As DateTime, total As Decimal)`: Inserta una nueva venta y devuelve su ID.
     - `InsertVentaItem(ventaID As Integer, productoID As Integer, cantidad As Integer, precioUnitario As Decimal, precioTotal As Decimal)`: Inserta un detalle de venta.
     - `SearchVentas(clientName As String, saleID As Integer?, startDate As DateTime?, endDate As DateTime?)`: Busca ventas basadas en criterios como cliente, ID o rango de fechas.
     - `GetSalesReport()`: Genera un informe detallado de ventas, incluyendo cliente, productos y totales.

5. **VentaItemDAL**
   - **Descripción**: Gestiona operaciones relacionadas con la tabla ventasitems.
   - **Métodos principales**:
     - `GetAllVentasItems()`: Retorna todos los registros de la tabla ventasitems.

## Proyecto: PRUEBADEMO.BLL
El proyecto "PRUEBADEMO.BLL" es una biblioteca de clases (.NET Framework) que contiene la lógica empresarial de la aplicación.

### Namespace y Ensamblado
- Nombre del ensamblado: `PRUEBADEMO.BLL`
- Namespace raíz: `PRUEBADEMO.BLL`

### Componentes
1. **Clases de Modelo**
   - Representan las entidades de negocio utilizadas en el sistema:
     - **Cliente**: Representa un cliente en el sistema.
     - **Venta**: Representa una venta.
     - **VentaItem**: Representa un detalle de venta (ítem vendido).
     - **Producto**: Representa un producto en el sistema.

2. **Clases de Negocio**
   - Gestionan la lógica relacionada con las diferentes entidades del sistema:
     - **ClienteBLL**
     - **VentaBLL**
     - **VentaItemBLL**
     - **ProductoBLL**

## Proyecto: UI
El proyecto "UI" contiene formularios que gestionan las diferentes funcionalidades del sistema. Cada formulario está enfocado en una entidad o funcionalidad específica.

### Namespace y Ensamblado
- Nombre del ensamblado: `UI`
- Namespace raíz: `UI`

### Componentes Principales
- **FrmMain**: Formulario principal de la aplicación, encargado de gestionar la navegación entre los diferentes módulos del sistema.
- **FrmClientes**: Formulario de gestión de clientes.
- **FrmProductos**: Formulario destinado a la gestión de productos.
- **FrmVentas**: Formulario que gestiona el registro de ventas.
- **FrmSalesReport**: Formulario dedicado a la visualización de un informe detallado de ventas.
- **FrmProductReport**: Formulario dedicado a la visualización de un informe detallado de ventas de productos.
- **FrmSearchVentas**: Formulario destinado a realizar búsquedas dinámicas de ventas y mostrar los resultados en una tabla.

## Consideraciones Técnicas Generales
- **Cadena de conexión**: Configurada en el archivo `App.config` bajo la clave "pruebademo".
- **SQL Injection**: Todas las consultas parametrizadas utilizan `SqlParameter` para prevenir inyecciones SQL.
- **Interfaz de Usuario**: Los controles están organizados para una interacción clara y fluida.