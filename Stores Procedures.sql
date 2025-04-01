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

CREATE PROC [dbo].[sp_RegistrarCategoria](
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





