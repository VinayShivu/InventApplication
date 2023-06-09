USE [master]
GO
/****** Object:  Database [InventApplication]    Script Date: 31-05-2023 11.03.52 AM ******/
CREATE DATABASE [InventApplication]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InventApplication', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER2017\MSSQL\DATA\InventApplication.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InventApplication_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER2017\MSSQL\DATA\InventApplication_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [InventApplication] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InventApplication].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InventApplication] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InventApplication] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InventApplication] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InventApplication] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InventApplication] SET ARITHABORT OFF 
GO
ALTER DATABASE [InventApplication] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InventApplication] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InventApplication] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InventApplication] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InventApplication] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InventApplication] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InventApplication] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InventApplication] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InventApplication] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InventApplication] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InventApplication] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InventApplication] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InventApplication] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InventApplication] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InventApplication] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InventApplication] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InventApplication] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InventApplication] SET RECOVERY FULL 
GO
ALTER DATABASE [InventApplication] SET  MULTI_USER 
GO
ALTER DATABASE [InventApplication] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InventApplication] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InventApplication] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InventApplication] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InventApplication] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'InventApplication', N'ON'
GO
ALTER DATABASE [InventApplication] SET QUERY_STORE = OFF
GO
USE [InventApplication]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 31-05-2023 11.03.52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[customerid] [int] IDENTITY(1,1) NOT NULL,
	[companyname] [varchar](max) NULL,
	[customergst] [varchar](max) NULL,
	[email] [varchar](max) NULL,
	[phone] [varchar](max) NULL,
	[address] [varchar](max) NULL,
	[primarycontactname] [varchar](max) NULL,
	[contactpersons] [varchar](max) NULL,
	[receivables] [int] NULL,
 CONSTRAINT [PK_buyer] PRIMARY KEY CLUSTERED 
(
	[customerid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[items]    Script Date: 31-05-2023 11.03.53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[items](
	[itemid] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](max) NULL,
	[description] [varchar](max) NULL,
	[unit] [varchar](max) NULL,
	[hsn] [int] NULL,
	[brand] [varchar](max) NULL,
	[partcode] [varchar](max) NULL,
	[gst] [int] NULL,
	[igst] [int] NULL,
	[sellingprice] [decimal](18, 2) NULL,
	[stock] [int] NULL,
	[status] [varchar](max) NULL,
 CONSTRAINT [PK_items] PRIMARY KEY CLUSTERED 
(
	[itemid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[registertbl]    Script Date: 31-05-2023 11.03.53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[registertbl](
	[userid] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](max) NULL,
	[password] [varchar](max) NULL,
	[email] [varchar](max) NULL,
	[roles] [varchar](50) NULL,
	[refreshtoken] [varchar](max) NULL,
	[refreshtokencreated] [datetime] NULL,
	[refreshtokenexpires] [datetime] NULL,
	[passwordresettoken] [varchar](max) NULL,
	[passwordresettokenexpires] [datetime] NULL,
 CONSTRAINT [PK_registertbl] PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vendor]    Script Date: 31-05-2023 11.03.53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vendor](
	[vendorid] [int] IDENTITY(1,1) NOT NULL,
	[companyname] [varchar](max) NULL,
	[vendorgst] [varchar](max) NULL,
	[email] [varchar](max) NULL,
	[phone] [varchar](max) NULL,
	[address] [varchar](max) NULL,
	[primarycontactname] [varchar](max) NULL,
	[contactpersons] [varchar](max) NULL,
	[payables] [int] NULL,
 CONSTRAINT [PK_supplier] PRIMARY KEY CLUSTERED 
(
	[vendorid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[customer] ON 

INSERT [dbo].[customer] ([customerid], [companyname], [customergst], [email], [phone], [address], [primarycontactname], [contactpersons], [receivables]) VALUES (2, N'sdasdsdafaf', N'dsasdsdads', N'qwerwer@dgfd.dg', N'1231231233', N'sdsd', N'sdssds', N'ssdsd', NULL)
INSERT [dbo].[customer] ([customerid], [companyname], [customergst], [email], [phone], [address], [primarycontactname], [contactpersons], [receivables]) VALUES (3, N'string', N'string', N'string', N'string', N'string', NULL, NULL, NULL)
INSERT [dbo].[customer] ([customerid], [companyname], [customergst], [email], [phone], [address], [primarycontactname], [contactpersons], [receivables]) VALUES (4, N'newname', N'282152522', N'string@gmail.com', N'1472583699', N'asdasdada', N'strsadasding', N'strsadasing', NULL)
INSERT [dbo].[customer] ([customerid], [companyname], [customergst], [email], [phone], [address], [primarycontactname], [contactpersons], [receivables]) VALUES (5, N'bhandara', N'29adfsfd56asas2', N'prwefsadcdasassa@gmail.com', N'9638527411', N'string', N'string', N'string', NULL)
INSERT [dbo].[customer] ([customerid], [companyname], [customergst], [email], [phone], [address], [primarycontactname], [contactpersons], [receivables]) VALUES (6, N'sdaafaf', N'dsadads', N'qwerwer@dgfd.dg', N'1231231233', N'sdsd', N'sds', N's', 0)
SET IDENTITY_INSERT [dbo].[customer] OFF
GO
SET IDENTITY_INSERT [dbo].[items] ON 

INSERT [dbo].[items] ([itemid], [name], [description], [unit], [hsn], [brand], [partcode], [gst], [igst], [sellingprice], [stock], [status]) VALUES (1, N'O', N'v', N'L', 8522, N'G', N'1', 18, 0, CAST(1.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[items] ([itemid], [name], [description], [unit], [hsn], [brand], [partcode], [gst], [igst], [sellingprice], [stock], [status]) VALUES (2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[items] ([itemid], [name], [description], [unit], [hsn], [brand], [partcode], [gst], [igst], [sellingprice], [stock], [status]) VALUES (3, N'New', N'il new xzx', N'Ltrs', 123466, N'goldwiner', N'1478', 18, 0, CAST(150.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[items] ([itemid], [name], [description], [unit], [hsn], [brand], [partcode], [gst], [igst], [sellingprice], [stock], [status]) VALUES (4, N'vegoil', N'vegoil new paxk', N'Ltrs', 123456, N'Goldwinnwer', N'SSDDFSadf', 18, 0, CAST(150.00 AS Decimal(18, 2)), NULL, NULL)
INSERT [dbo].[items] ([itemid], [name], [description], [unit], [hsn], [brand], [partcode], [gst], [igst], [sellingprice], [stock], [status]) VALUES (5, N'newitem', N'vegoil', N'Ltrs', 8382, N'Gold', N'1234632', 18, 10, CAST(120.00 AS Decimal(18, 2)), 0, NULL)
INSERT [dbo].[items] ([itemid], [name], [description], [unit], [hsn], [brand], [partcode], [gst], [igst], [sellingprice], [stock], [status]) VALUES (6, N'newireg', N'new addeing item', N'NOS', 2252, N'zirkom', N'14711', 18, 0, CAST(141.00 AS Decimal(18, 2)), 0, N'Active')
INSERT [dbo].[items] ([itemid], [name], [description], [unit], [hsn], [brand], [partcode], [gst], [igst], [sellingprice], [stock], [status]) VALUES (7, N'nesdsdwireg', N'new addeing item', N'NOS', 2252, N'zirkom', N'14711', 18, 0, CAST(141.00 AS Decimal(18, 2)), 0, N'Active')
INSERT [dbo].[items] ([itemid], [name], [description], [unit], [hsn], [brand], [partcode], [gst], [igst], [sellingprice], [stock], [status]) VALUES (8, N'nesdsdwi', N'new addeing item', N'NOS', 2252, N'zirkom', N'14711', 18, 0, CAST(141.00 AS Decimal(18, 2)), 0, N'Active')
SET IDENTITY_INSERT [dbo].[items] OFF
GO
SET IDENTITY_INSERT [dbo].[registertbl] ON 

INSERT [dbo].[registertbl] ([userid], [username], [password], [email], [roles], [refreshtoken], [refreshtokencreated], [refreshtokenexpires], [passwordresettoken], [passwordresettokenexpires]) VALUES (13, N'pree', N'$2a$10$TgiWOHFu3BnAbb1tVhylI.8/nMk2Ap0XwXWYLAptqqCNERTqSwpJu', N'preethamcgowdaa@gmail.com', N'Admin', N'4dfdb36f-3a9b-4bf9-b0cd-032bbb5f5c2f', CAST(N'2023-05-17T12:59:56.447' AS DateTime), CAST(N'2023-05-18T12:59:56.447' AS DateTime), NULL, NULL)
INSERT [dbo].[registertbl] ([userid], [username], [password], [email], [roles], [refreshtoken], [refreshtokencreated], [refreshtokenexpires], [passwordresettoken], [passwordresettokenexpires]) VALUES (14, N'mys', N'$2a$10$.9pf2yFRLFRZ274q6r1wj.VK.EOYsy5MzgFMBvk9ROp7XZepQBBae', NULL, N'Admin', N'0ad0eb4f-d4a0-43cc-b774-0d52bd1b1923', CAST(N'2023-05-08T14:41:15.840' AS DateTime), CAST(N'2023-05-09T14:41:15.840' AS DateTime), NULL, NULL)
INSERT [dbo].[registertbl] ([userid], [username], [password], [email], [roles], [refreshtoken], [refreshtokencreated], [refreshtokenexpires], [passwordresettoken], [passwordresettokenexpires]) VALUES (15, N'preetham', N'$2a$10$RVJbdn9zy49E6y30P3NNM.90CgwqULrowqUjnDSCe/JFdWTs9aBYu', N'preetha@gmail.com', N'User', N'1c4db326-c940-4cb5-8a29-605a376962d5', CAST(N'2023-05-15T17:24:39.553' AS DateTime), CAST(N'2023-05-16T17:24:39.553' AS DateTime), N'89ded6ad-6077-4388-8c1b-090ba491a214', CAST(N'2023-05-17T12:07:57.253' AS DateTime))
INSERT [dbo].[registertbl] ([userid], [username], [password], [email], [roles], [refreshtoken], [refreshtokencreated], [refreshtokenexpires], [passwordresettoken], [passwordresettokenexpires]) VALUES (1015, N'password', N'$2a$10$A8MRjaduKBPmyB8ANlKrkuqwLQCh581WvnblZqhwxpNtIziHfdZKi', N'pra@gmail.com', N'Admin', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[registertbl] ([userid], [username], [password], [email], [roles], [refreshtoken], [refreshtokencreated], [refreshtokenexpires], [passwordresettoken], [passwordresettokenexpires]) VALUES (1016, N'passwords', N'$2a$10$GXYelQ1txY./MFvwchEfqOWuNWeYQIz.Nl5OUQCzoKuUkLVIyoelW', N'preethamcgowda@gmail.com', N'Admin', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[registertbl] ([userid], [username], [password], [email], [roles], [refreshtoken], [refreshtokencreated], [refreshtokenexpires], [passwordresettoken], [passwordresettokenexpires]) VALUES (1017, N'preeth', N'$2a$10$X.Qu65sWbav.0IBsqNNG7euy4VVBYetG.B7F5IJ0eofwf9qjvZC.C', N'preethamcgow@gmail.com', N'User', N'f08cd9df-5706-4d83-bcb1-97244b883297', CAST(N'2023-05-16T19:28:42.397' AS DateTime), CAST(N'2023-05-17T19:28:42.397' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[registertbl] OFF
GO
SET IDENTITY_INSERT [dbo].[vendor] ON 

INSERT [dbo].[vendor] ([vendorid], [companyname], [vendorgst], [email], [phone], [address], [primarycontactname], [contactpersons], [payables]) VALUES (1, N'newzxzxsds', N'29adfsfd56asas2', N'prwefsadcdasassa@gmail.com', N'9638527411', N'string', N'string', N'string', 100)
INSERT [dbo].[vendor] ([vendorid], [companyname], [vendorgst], [email], [phone], [address], [primarycontactname], [contactpersons], [payables]) VALUES (2, N'NewVendor2', N'29ASDASFASFASF2', N'aascascsaca@gmail.com2', N'9638271552', N'[{"sdsdsdsds":0,"name":"expenseType","required":true,"type":"text","placeholder":"Expense Type"},{"order":1,"name":"date","required":true,"type":"text","placeholder":"Expense Date"},{"order":3,"name":"amount","required":true,"type":"number","placeholder":"Enter Amount"},{"order":4,"name":"description","required":true,"type":"text","placeholder":"Description"},{"order":5,"name":"imageUrls","type":"fileUpload","options":"asdasdsa"}]', N'963982152154125', N'[{"sdsdsd":0,"name":"expenseType","required":true,"type":"text","placeholder":"Expense Type"},{"order":1,"name":"date","required":true,"type":"text","placeholder":"Expense Date"},{"order":3,"name":"amount","required":true,"type":"number","placeholder":"Enter Amount"},{"order":4,"name":"description","required":true,"type":"text","placeholder":"Description"},{"order":5,"name":"imageUrls","type":"fileUpload","options":"asdasdsa"}]', 200)
INSERT [dbo].[vendor] ([vendorid], [companyname], [vendorgst], [email], [phone], [address], [primarycontactname], [contactpersons], [payables]) VALUES (3, N'newvwndoir', N'29asdasdsad', N'pweradzx@gmail.com', N'9638527411', N'mysiere', N'wasdas', N'dsC', 300)
INSERT [dbo].[vendor] ([vendorid], [companyname], [vendorgst], [email], [phone], [address], [primarycontactname], [contactpersons], [payables]) VALUES (5, N'newvwndoir', N'29asdasdsad', N'pweradzx@gmail.com', N'9638527411', N'mysiere', N'wasdas', N'dsC', 400)
INSERT [dbo].[vendor] ([vendorid], [companyname], [vendorgst], [email], [phone], [address], [primarycontactname], [contactpersons], [payables]) VALUES (6, N'newzxzxsdsd', N'39asdsDsdsd', N'stringsds@gmail.com', N'9638527411', N'string', N'string', N'string', 0)
INSERT [dbo].[vendor] ([vendorid], [companyname], [vendorgst], [email], [phone], [address], [primarycontactname], [contactpersons], [payables]) VALUES (7, N'weasasqwee', N'23232323e12', N'sdasdf@gmail.com', N'9638527411', N'strasdsading', N'strasdasding', N'strizsadasdang', 0)
SET IDENTITY_INSERT [dbo].[vendor] OFF
GO
/****** Object:  StoredProcedure [dbo].[additems]    Script Date: 31-05-2023 11.03.53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[additems]
	@name varchar(MAX),
	@description varchar(MAX),
	@unit varchar(MAX),
	@hsn int,
	@brand varchar(MAX),
	@partcode varchar(MAX),
	@gst int,
	@igst int,
	@sellingprice decimal(18,2),
	@stock int,
	@status varchar(MAX),
	@Result int OUTPUT


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	  BEGIN TRY
        INSERT INTO items(name,description,unit,hsn,brand, partcode,gst,igst,sellingprice,stock,status) VALUES (@name,@description,@unit,@hsn,@brand,@partcode,@gst,@igst,@sellingprice,@stock,@status);
        SET @Result = 1; -- Success
    END TRY
    BEGIN CATCH
        SET @Result = 0; -- Failure
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[getallitems]    Script Date: 31-05-2023 11.03.53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getallitems]
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DECLARE @SqlQuery NVARCHAR(MAX) = N'SELECT * FROM items;';

        EXEC (@SqlQuery);
    END TRY
    BEGIN CATCH
        -- Handle the exception
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        -- Log the error or perform any necessary actions

        -- Raise the error to the caller
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[getitembyid]    Script Date: 31-05-2023 11.03.53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getitembyid]
	@itemid INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
			DECLARE @SqlQuery NVARCHAR(MAX) = N'SELECT * FROM items WHERE itemid = @itemid';

			EXEC sp_executesql @SqlQuery, N'@itemid INT', @itemid;
    END TRY
    BEGIN CATCH
        -- Handle the exception
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        -- Log the error or perform any necessary actions

        -- Raise the error to the caller
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[getitembyname]    Script Date: 31-05-2023 11.03.53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getitembyname]
    @itemname VARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Check if the item exists
        IF NOT EXISTS (SELECT 1 FROM items WHERE Name = @itemname)
        BEGIN
            RETURN null;
        END

        -- Retrieve the item
        SELECT itemid, name, description, unit, hsn, brand, partcode, gst, igst, sellingprice, stock,status
        FROM items
        WHERE name = @itemname;
    END TRY
    BEGIN CATCH
        -- Handle the exception
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        -- Log the error or perform any necessary actions

        -- Raise the error to the caller
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END
GO
USE [master]
GO
ALTER DATABASE [InventApplication] SET  READ_WRITE 
GO
