IF NOT EXISTS(SELECT * FROM sys.databases where name = N'TestDB')
   CREATE DATABASE [TestDB]
GO
USE [TestDB]
GO
IF OBJECT_ID('dbo.as_branch_quala') IS NOT NULL
    DROP TABLE [dbo].[as_branch_quala]
GO
CREATE TABLE [dbo].[as_branch_quala](
	[code] [int] NOT NULL,
	[description] [nvarchar](250) NOT NULL,
	[address] [nvarchar](250) NOT NULL,
	[identification] [nvarchar](50) NOT NULL,
	[creation_date] [date] NOT NULL,
	[currency] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
IF OBJECT_ID('dbo.as_currency') IS NOT NULL
    DROP TABLE [dbo].[as_currency]
GO
CREATE TABLE [dbo].[as_currency](
	[code] [int] NOT NULL,
	[currency] [nvarchar](50) NULL,
 CONSTRAINT [PK_as_currency] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT INTO as_currency (code, currency) VALUES ('1', 'Peso Colombian COP'), ('2','Dolor Estadounidense - USD'), ('3','Dolor Canadiense - CAD'), ('4', 'Euro - EUR'), ('5', 'Yuan Chino - CNY')
GO
INSERT INTO as_branch_quala VALUES ('1','SUCURSAL 1', 'CAlle 90 54-52', '123456','20251224','1' ),('2','SUCURSAL 2', 'CAlle 90 -30', '585425','20241224','2' ),('3','SUCURSAL 3', 'CAlle 88 -30', '7411452','20231224','3' )
GO
CREATE PROCEDURE sp_Get_as_branches_quala 	
AS
BEGIN
	SELECT b.code, b.description, b.address, b.identification, b.creation_date, c.currency 
	FROM [dbo].[as_branch_quala] b INNER JOIN [dbo].[as_currency] c ON (b.currency = c.code)
END
GO
CREATE PROCEDURE sp_Insert_as_branches_quala
    @code INT,
    @description NVARCHAR(250),
    @address NVARCHAR(250),
    @identification NVARCHAR(50),
    @creation_date NVARCHAR(30),
    @currency INT
AS
BEGIN
    SET NOCOUNT ON
	declare @cant INT
	SELECT @cant = ISNULL(COUNT(*), 0) + 1 FROM [dbo].[as_branch_quala]

    INSERT INTO [dbo].[as_branch_quala] (
        code, description, address, identification, creation_date, currency
    )
    VALUES (
        @cant, UPPER(@description), UPPER(@address), @identification, GETDATE(), @currency
    )
END
GO
CREATE PROCEDURE sp_Update_as_branches_quala
    @code INT,
    @description NVARCHAR(250),
    @address NVARCHAR(250),
    @identification NVARCHAR(50),
    @creation_date NVARCHAR(30),
    @currency INT
AS
BEGIN
    SET NOCOUNT ON
    UPDATE [dbo].[as_branch_quala]
    SET
        description = UPPER(@description),
        address = UPPER(@address),
        identification = @identification,
        creation_date = CAST(@creation_date as date),
        currency = @currency
    WHERE
        code = @code
END
GO
CREATE PROCEDURE sp_Delete_as_brances_quala
    @code INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM [dbo].[as_branch_quala]
    WHERE code = @code
END
GO
CREATE PROCEDURE sp_Get_as_branches_quala_By_Code 	
 @code INT
AS
BEGIN
	SELECT b.code, b.description, b.address, b.identification, b.creation_date, c.currency 
	FROM [dbo].[as_branch_quala] b INNER JOIN [dbo].[as_currency] c ON (b.currency = c.code) WHERE b.code = @code
END
GO
CREATE TABLE [dbo].[as_users](
	[nameuser] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NULL,
	[rol] [nvarchar](50) NULL
 CONSTRAINT [PK_as_users] PRIMARY KEY CLUSTERED 
(
	[nameuser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT INTO [dbo].[as_users] VALUES ('admin@admin', 'HwrVG0FbJ330b54T93MpHeDK47bZKGjDd5het25YCWE=','Admin')
GO
CREATE PROCEDURE sp_Get_as_users_By_User 	
 @nameuser nvarchar(50)
AS
BEGIN
	SELECT * FROM [dbo].[as_users] WHERE nameuser = @nameuser
END
GO
CREATE PROCEDURE sp_Get_as_currency
AS
BEGIN
  SELECT* FROM as_currency
END


