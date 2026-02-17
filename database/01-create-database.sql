CREATE DATABASE PruebaSD;
GO

USE PruebaSD;
GO

CREATE TABLE Usuario (
    usulD numeric(18, 0) NOT NULL PRIMARY KEY,
    nombre varchar(100) NULL,
    apellido varchar(100) NULL
);
GO

INSERT INTO Usuario (usulD, nombre, apellido) VALUES
(1, 'Andres', 'Rodriguez Vera'),
(2, 'Jose', 'Giraldo Perez'),
(3, 'Maria', 'Lopez Garcia'),
(4, 'Carlos', 'Martinez Ruiz'),
(5, 'Ana', 'Fernandez Soto');
GO
