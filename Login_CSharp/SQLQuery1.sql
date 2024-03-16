use Login_csharp

CREATE TABLE [dbo].[Usuarios]
(
    [ID] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](50) NULL,
    [CodUsua] [varchar](20) NOT NULL,
    [Contra] [varbinary](max) NULL,
    [EsAdmin] [smallint] NULL,
)

SELECT * FROM Usuarios

-- Insertando Valores
INSERT INTO Usuarios VALUES ('Jesus', 'Jesus004', '12345', 1),
                            ('Ricardo', 'Ricardo007', '54321', 0);