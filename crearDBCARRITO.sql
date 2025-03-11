CREATE TABLE Categoria(
	IdCategoria INT PRIMARY KEY IDENTITY,
	Descripcion VARCHAR(100),
	Activo BIT DEFAULT 1,
	FechaRegistro DATETIME DEFAULT GETDATE()
);

CREATE TABLE Marca(
	IdMarca INT PRIMARY KEY IDENTITY,
	Descripcion VARCHAR(100),
	Activo BIT DEFAULT 1,
	FechaRegistro DATETIME DEFAULT GETDATE()
);

CREATE TABLE Producto(
	IdProducto INT PRIMARY KEY IDENTITY,
	Nombre VARCHAR(500),
	Descripcion VARCHAR(100),
	IdMarca INT REFERENCES Marca(IdMarca),
	IdCategoria INT REFERENCES Categoria(IdCategoria),
	Precio DECIMAL(10,2) DEFAULT 0,
	Stock INT,
	RutaImagen VARCHAR(100),
	NombreImagen VARCHAR(100),
	Activo BIT DEFAULT 1,
	FechaRegistro DATETIME DEFAULT GETDATE()
);

CREATE TABLE Cliente(
	IdCliente INT PRIMARY KEY IDENTITY,
	Nombres VARCHAR(100),
	Apellidos VARCHAR(100),
	Correo VARCHAR(100),
	Clave VARCHAR(150),
	Restablecer BIT DEFAULT 0,
	FechaRegistro DATETIME DEFAULT GETDATE()
);

CREATE TABLE Carrito(
	IdCarrito INT PRIMARY KEY IDENTITY,
	IdCliente INT REFERENCES Cliente(IdCliente),
	IdProducto INT REFERENCES Producto(IdProducto),
	Cantidad INT
);

CREATE TABLE Venta(
	IdVenta INT PRIMARY KEY IDENTITY,
	IdCliente INT REFERENCES Cliente(IdCliente),
	TotalProducto INT,
	MontoTotal DECIMAL(10,2),
	Contacto VARCHAR(50),
	IdDistrito VARCHAR(10),
	Telefono VARCHAR(50),
	Direccion VARCHAR(500),
	IdTransaccion VARCHAR(500),
	FechaVenta DATETIME DEFAULT GETDATE()
);

CREATE TABLE DetalleVenta(
	IdDetalleVenta INT PRIMARY KEY IDENTITY,
	IdVenta INT REFERENCES Venta(Idventa),
	IdProducto INT REFERENCES Producto(IdProducto),
	Cantidad INT,
	Total DECIMAL(10,2)
);

CREATE TABLE Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Nombres VARCHAR(100),
	Apellidos VARCHAR(100),
	Correo VARCHAR(100),
	Clave VARCHAR(150),
	Restablecer BIT DEFAULT 1,
	Activo BIT DEFAULT 1,
	FechaRegistro DATETIME DEFAULT GETDATE()
);

CREATE TABLE Departamento(
	IdDepartamento VARCHAR(2) NOT NULL,
	Descripcion VARCHAR(45) NOT NULL	
)

CREATE TABLE Provincia(
	IdProvincia VARCHAR(4) NOT NULL,
	Descripcion VARCHAR(45) NOT NULL,
	IdDepartamento VARCHAR(2) NOT NULL
)

CREATE TABLE Distrito(
	IdDistrito VARCHAR(6) NOT NULL,
	IdProvincia VARCHAR(4) NOT NULL,
	Descripcion VARCHAR(45) NOT NULL,
	IdDepartamento VARCHAR(2) NOT NULL
)
