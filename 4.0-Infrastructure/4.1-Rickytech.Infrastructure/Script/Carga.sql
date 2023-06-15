CREATE DATABASE Rickytech
GO
USE Rickytech
GO
IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME = 'Category')
    DROP TABLE Category
GO
CREATE TABLE Category
(
    Id                  INT             NOT NULL PRIMARY KEY IDENTITY(1,1)
,   OperationId         INT             NOT NULL
,   Name                VARCHAR(100)    NOT NULL
,   Enabled             BIT             NOT NULL DEFAULT(1)
,   CreatedDate         DATETIME        NOT NULL DEFAULT(GETDATE())
,   ChangedDate         DATETIME            NULL
)

IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME = 'Operation')
    DROP TABLE Operation
GO
CREATE TABLE Operation
(
    Id                  INT             NOT NULL PRIMARY KEY IDENTITY(1,1)
,   Name                VARCHAR(100)    NOT NULL          
)
INSERT INTO Operation(Name) VALUES ('Crédito')
INSERT INTO Operation(Name) VALUES ('Débito')

IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME = 'Flow')
    DROP TABLE Flow
GO
CREATE TABLE Flow
(
    Id                  INT             NOT NULL PRIMARY KEY IDENTITY(1,1)
,   Name                VARCHAR(100)    NOT NULL
,   CategoryId          INT             NOT NULL
,   OperationValue      DECIMAL(18,2)   NOT NULL
,   OperationDate       DATETIME        NOT NULL
,   Enabled             BIT             NOT NULL DEFAULT(1)
,   CreatedDate         DATETIME        NOT NULL DEFAULT(GETDATE())
,   ChangedDate         DATETIME            NULL

)


