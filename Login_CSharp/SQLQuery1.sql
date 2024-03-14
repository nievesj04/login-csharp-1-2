use Login_csharp

CREATE TABLE [dbo].[Usuarios]
(
    [ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] VARCHAR(50) NULL,
    [User] VARCHAR(50) NULL,
    [Password] VARCHAR(50) NULL,
    [User_type] VARCHAR(50) NULL,
)

SELECT * FROM Usuarios

-- Insertando Valores
INSERT INTO Usuarios VALUES ('Jesus', 'Jesus004', '12345', 'Admin'),
                            ('Ricardo', 'Ricardo007', '54321', 'User');