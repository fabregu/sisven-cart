CREATE PROC sp_RegistrarUsuario(
	@Nombres VARCHAR(100),
	@Apellidos VARCHAR(100),
	@Correo VARCHAR(100),
	@Clave VARCHAR(100),
	@Activo BIT,
	@Mensaje VARCHAR(500) OUTPUT,
	@Resultado INT OUTPUT
)
AS
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS(SELECT * FROM Usuario WHERE Correo = @Correo)
	BEGIN
		INSERT INTO Usuario(Nombres, Apellidos, Correo, Clave, Activo) VALUES
		(@Nombres, @Apellidos, @Correo, @Clave, @Activo)
		SET @Resultado = SCOPE_IDENTITY()
	END
	ELSE
		SET @Mensaje = 'El correo del usuario ya existe'
END
GO

CREATE PROC sp_EditarUsuario(
	@IdUsuario INT,
	@Nombres VARCHAR(100),
	@Apellidos VARCHAR(100),
	@Correo VARCHAR(100),
	@Clave VARCHAR(100),
	@Activo BIT,
	@Mensaje VARCHAR(500) OUTPUT,
	@Resultado BIT OUTPUT
)
AS
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS(SELECT * FROM Usuario WHERE Correo = @Correo AND IdUsuario != @IdUsuario)
	BEGIN
		UPDATE TOP(1)Usuario SET
		Nombres = @Nombres,
		Apellidos = @Apellidos,
		Correo = @Correo, 
		Activo= @Activo
		SET @Resultado = 1
	END
	ELSE
		SET @Mensaje = 'El correo del usuario ya existe'
END
GO

-- CATEGORIAS

CREATE PROC sp_RegistrarCategoria](
	@Descripcion VARCHAR(100),
	@Activo BIT,
	@Mensaje VARCHAR(500) OUTPUT,
	@Resultado INT OUTPUT
)
AS
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS(SELECT * FROM Categoria WHERE Descripcion = @Descripcion)
	BEGIN
		INSERT INTO Categoria(Descripcion, Activo) VALUES
		(@Descripcion, @Activo)
		SET @Resultado = SCOPE_IDENTITY()
	END
	ELSE
		SET @Mensaje = 'La categoria ya existe'
END

GO

CREATE PROC sp_EditarCategoria(
	@IdCategoria INT,
	@Descripcion VARCHAR(100),
	@Activo BIT,
	@Mensaje VARCHAR(500) OUTPUT,
	@Resultado BIT OUTPUT
)
AS
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS(SELECT * FROM Categoria WHERE Descripcion = @Descripcion AND IdCategoria != @IdCategoria )
	BEGIN
		UPDATE TOP(1)Categoria SET
		Descripcion = @Descripcion,
		Activo= @Activo
		SET @Resultado = 1
	END
	ELSE
		SET @Mensaje = 'La categoria ya existe'
END
GO

CREATE PROC sp_EliminarCategoria(
	@IdCategoria INT,
	@Mensaje VARCHAR(500) OUTPUT,
	@Resultado BIT OUTPUT
)
AS
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS(SELECT * FROM Producto p INNER JOIN Categoria c ON c.IdCategoria = p.IdCategoria WHERE p.IdCategoria = @IdCategoria)
	BEGIN
		DELETE TOP(1) FROM Categoria WHERE IdCategoria = @IdCategoria
		SET @Resultado = 1
	END
	ELSE
		SET @Mensaje = 'La categoria se encuentra relacionada a un producto'
END
GO

-- MARCAS

CREATE PROC sp_RegistrarMarca(
	@Descripcion VARCHAR(100),
	@Activo BIT,
	@Mensaje VARCHAR(500) OUTPUT,
	@Resultado INT OUTPUT
)
AS
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS(SELECT * FROM Marca WHERE Descripcion = @Descripcion)
	BEGIN
		INSERT INTO Marca(Descripcion, Activo) VALUES
		(@Descripcion, @Activo)
		SET @Resultado = SCOPE_IDENTITY()
	END
	ELSE
		SET @Mensaje = 'La marca ya existe'
END

GO

CREATE PROC sp_EditarMarca(
	@IdMarca INT,
	@Descripcion VARCHAR(100),
	@Activo BIT,
	@Mensaje VARCHAR(500) OUTPUT,
	@Resultado BIT OUTPUT
)
AS
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS(SELECT * FROM Marca WHERE Descripcion = @Descripcion AND IdMarca != @IdMarca )
	BEGIN
		UPDATE TOP(1)Marca SET
		Descripcion = @Descripcion,
		Activo= @Activo
		SET @Resultado = 1
	END
	ELSE
		SET @Mensaje = 'La marca ya existe'
END
GO

CREATE PROC sp_EliminarMarca(
	@IdMarca INT,
	@Mensaje VARCHAR(500) OUTPUT,
	@Resultado BIT OUTPUT
)
AS
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS(SELECT * FROM Producto p INNER JOIN Marca c ON c.IdMarca = p.IdCategoria WHERE p.IdMarca = @IdMarca)
	BEGIN
		DELETE TOP(1) FROM Marca WHERE IdMarca = @IdMarca
		SET @Resultado = 1
	END
	ELSE
		SET @Mensaje = 'La marca se encuentra relacionada a un producto'
END
GO

-- PRODUCTOS
CREATE PROC sp_RegistrarProducto(
	@Nombre VARCHAR(100),
	@Descripcion VARCHAR(100),
	@IdMarca VARCHAR(100),
	@IdCategoria VARCHAR(100),
	@Precio DECIMAL(10,2),
	@Stock INT,
	@Activo BIT,
	@Mensaje VARCHAR(500) OUTPUT,
	@Resultado INT OUTPUT
)
AS
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS(SELECT * FROM Producto WHERE Nombre = @Nombre)
	BEGIN
		INSERT INTO Producto(Nombre, Descripcion, IdMarca, IdCategoria, Precio, Stock, Activo) VALUES
		(@Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio, @Stock, @Activo)
		SET @Resultado = SCOPE_IDENTITY()
	END
	ELSE
		SET @Mensaje = 'El producto ya existe'
END
GO

CREATE PROC sp_EditarProducto(
	@IdProducto INT,
	@Nombre VARCHAR(100),
	@Descripcion VARCHAR(100),
	@IdMarca VARCHAR(100),
	@IdCategoria VARCHAR(100),
	@Precio DECIMAL(10,2),
	@Stock INT,
	@Activo BIT,
	@Mensaje VARCHAR(500) OUTPUT,
	@Resultado INT OUTPUT
)
AS
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS(SELECT * FROM Producto WHERE Nombre = @Nombre AND IdProducto != @IdProducto)
	BEGIN
		UPDATE TOP(1)Producto SET
		Nombre = @Nombre,
		Descripcion = @Descripcion,
		IdMarca = @IdMarca,
		IdCategoria = @IdCategoria,
		Precio = @Precio,
		Stock = @Stock,
		Activo= @Activo
		SET @Resultado = 1
	END
	ELSE
		SET @Mensaje = 'El producto ya existe'
END
GO

CREATE PROC sp_EliminarProducto(
	@IdProducto INT,
	@Mensaje VARCHAR(500) OUTPUT,
	@Resultado BIT OUTPUT
)
AS
BEGIN
	SET @Resultado = 0
	IF NOT EXISTS(SELECT * FROM DetalleVenta dv INNER JOIN Producto p ON p.IdProducto = dv.IdProducto WHERE p.IdProducto = @IdProducto)
	BEGIN
		DELETE TOP(1) FROM Producto WHERE IdProducto = @IdProducto
		SET @Resultado = 1
	END
	ELSE
		SET @Mensaje = 'El producto se encuentra relacionada a una venta'
END
GO

CREATE PROC sp_RutaImagenes(
    @IdProducto INT,
    @RutaImagen VARCHAR(100),
    @NombreImagen VARCHAR(100) 
)
AS
    BEGIN
   IF NOT EXISTS(SELECT * FROM PRODUCTO WHERE idProducto != @IdProducto)
    UPDATE PRODUCTO SET RutaImagen = @RutaImagen, NombreImagen =@NombreImagen WHERE idProducto =@idProducto
    END
GO




