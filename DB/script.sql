USE [master]
GO
/****** Object:  Database [InventApplication]    Script Date: 19-10-2023 3.06.45 PM ******/
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
/****** Object:  Table [dbo].[vendor]    Script Date: 19-10-2023 3.06.45 PM ******/
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
	[payables] [decimal](18, 2) NULL,
	[remarks] [varchar](max) NULL,
	[isdeleted] [varchar](50) NULL,
 CONSTRAINT [PK_supplier] PRIMARY KEY CLUSTERED 
(
	[vendorid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[getdropdownlistfun]    Script Date: 19-10-2023 3.06.45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[getdropdownlistfun]()
RETURNS TABLE
AS
RETURN
(
    WITH Details AS
    (
        SELECT v.vendorid AS id, v.companyname AS name, 'vendorname' AS field
        FROM dbo.vendor v
        WHERE v.isdeleted = 'false'
   
    )
    SELECT id, name, field
    FROM Details
);
GO
/****** Object:  Table [dbo].[customer]    Script Date: 19-10-2023 3.06.45 PM ******/
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
/****** Object:  Table [dbo].[items]    Script Date: 19-10-2023 3.06.45 PM ******/
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
/****** Object:  Table [dbo].[paymentterms]    Script Date: 19-10-2023 3.06.45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[paymentterms](
	[paymenttermsid] [int] IDENTITY(1,1) NOT NULL,
	[termname] [varchar](max) NULL,
	[numberofdays] [varchar](max) NULL,
 CONSTRAINT [PK_paymentterms] PRIMARY KEY CLUSTERED 
(
	[paymenttermsid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[purchase]    Script Date: 19-10-2023 3.06.45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purchase](
	[purchaseid] [int] IDENTITY(1,1) NOT NULL,
	[vendorid] [int] NULL,
	[vendorname] [varchar](max) NULL,
	[billno] [varchar](max) NULL,
	[billdate] [varchar](max) NULL,
	[paymentterms] [varchar](max) NULL,
	[duedate] [varchar](max) NULL,
	[itemsdata] [varchar](max) NULL,
	[totalbasicamount] [decimal](18, 2) NULL,
	[totalgst] [int] NULL,
	[totaligst] [int] NULL,
	[totalamount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_purchase] PRIMARY KEY CLUSTERED 
(
	[purchaseid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[registertbl]    Script Date: 19-10-2023 3.06.45 PM ******/
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
/****** Object:  Table [dbo].[tbl_activity_log]    Script Date: 19-10-2023 3.06.45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_activity_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[comments] [varchar](max) NULL,
	[ipaddress] [varchar](max) NULL,
	[userid] [int] NULL,
	[createdon] [datetime] NULL,
 CONSTRAINT [PK_tbl_activity_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_purchaseorder]    Script Date: 19-10-2023 3.06.45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_purchaseorder](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[vendorids] [int] NULL,
	[purchase_order_no] [varchar](max) NULL,
	[reference_no] [varchar](max) NULL,
	[po_date] [datetime] NULL,
	[expected_delivery_date] [datetime] NULL,
	[payment_terms] [varchar](max) NULL,
	[terms_and_conditions] [varchar](max) NULL,
	[isreceived] [varchar](max) NULL,
	[isdeleted] [varchar](max) NULL,
	[createdby] [int] NULL,
 CONSTRAINT [PK_purchaseorder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_purchaseorder_items_mappingtable]    Script Date: 19-10-2023 3.06.45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_purchaseorder_items_mappingtable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[purchase_order_id] [int] NULL,
	[item_id] [int] NULL,
	[purchase_qty] [int] NULL,
	[purchase_price] [decimal](18, 2) NULL,
	[subtotal] [decimal](18, 2) NULL,
	[gsttotal] [decimal](18, 2) NULL,
	[grandtotal] [decimal](18, 2) NULL,
 CONSTRAINT [PK__purchase__3213E83F9F2A987E] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[vendor] ADD  CONSTRAINT [DF_vendor_isdeleted]  DEFAULT ('false') FOR [isdeleted]
GO
ALTER TABLE [dbo].[tbl_purchaseorder_items_mappingtable]  WITH CHECK ADD  CONSTRAINT [FK__purchaseo__item___22401542] FOREIGN KEY([item_id])
REFERENCES [dbo].[items] ([itemid])
GO
ALTER TABLE [dbo].[tbl_purchaseorder_items_mappingtable] CHECK CONSTRAINT [FK__purchaseo__item___22401542]
GO
ALTER TABLE [dbo].[tbl_purchaseorder_items_mappingtable]  WITH CHECK ADD  CONSTRAINT [FK__purchaseo__purch__214BF109] FOREIGN KEY([purchase_order_id])
REFERENCES [dbo].[tbl_purchaseorder] ([id])
GO
ALTER TABLE [dbo].[tbl_purchaseorder_items_mappingtable] CHECK CONSTRAINT [FK__purchaseo__purch__214BF109]
GO
/****** Object:  StoredProcedure [dbo].[activityloginsert]    Script Date: 19-10-2023 3.06.45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[activityloginsert]
    @activitylogdata nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;
    DECLARE @Comments nvarchar(max);
    DECLARE @IpAddress nvarchar(max);
    DECLARE @UserId bigint;

    SELECT @Comments = JSON_VALUE(@activitylogdata, '$.Comments');
    SELECT @IpAddress = JSON_VALUE(@activitylogdata, '$.IpAddress');
    SELECT @UserId = CAST(JSON_VALUE(@activitylogdata, '$.UserId') AS bigint);

    INSERT INTO dbo.tbl_activity_log (comments, ipaddress, userid, createdon)
    VALUES (@Comments, @IpAddress, @UserId, GETDATE());

END;
GO
/****** Object:  StoredProcedure [dbo].[additems]    Script Date: 19-10-2023 3.06.45 PM ******/
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
/****** Object:  StoredProcedure [dbo].[addpurchaseorder]    Script Date: 19-10-2023 3.06.45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create   PROCEDURE  [dbo].[addpurchaseorder]
    @purchaseorderdata nvarchar(Max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @purchaseorderid int;
    DECLARE @slabData nvarchar(max);
    DECLARE @slabItem nvarchar(max);

	BEGIN
	  -- Insert into 
	 INSERT INTO dbo.tbl_purchaseorder(
		vendorids,
		purchase_order_no,
		reference_no,
		po_date,
		expected_delivery_date,
		payment_terms,
		terms_and_conditions,
		isreceived,
		isdeleted,
		createdby
	 )
	 VALUES (
		CAST(JSON_VALUE(@purchaseorderdata, '$.VendorID') AS int),
		     JSON_VALUE(@purchaseorderdata, '$.PurchaseOrderNumber'),
			 JSON_VALUE(@purchaseorderdata, '$.ReferenceNumber'),
			 CAST(JSON_VALUE(@purchaseorderdata, '$.PODate') AS datetime),
			 CAST(JSON_VALUE(@purchaseorderdata, '$.ExpectedDeliveryDate') AS datetime),
			 JSON_VALUE(@purchaseorderdata, '$.PaymentTerms'),
			 JSON_VALUE(@purchaseorderdata, '$.TermsandConditions'),
			 JSON_VALUE(@purchaseorderdata, '$.IsReceived'),
			 'false',
			 CAST(JSON_VALUE(@purchaseorderdata, '$.CreatedBy') AS int)
			 );
		END
			SET @purchaseorderid = SCOPE_IDENTITY();

	-- Update the Purchase Order Number
    IF EXISTS (SELECT 1 FROM dbo.tbl_purchaseorder WHERE id = @purchaseorderid AND isdeleted = 'false')
    BEGIN
        UPDATE dbo.tbl_purchaseorder
        SET purchase_order_no = 'PO-'  + CONVERT(VARCHAR(Max), @purchaseorderid) 
        WHERE id = @purchaseorderid AND isdeleted = 'false';
    END

	  -- Iterate through the JSON array for mapping table
    SET @slabData = JSON_QUERY(@purchaseorderdata, '$.ItemDetails');
	DECLARE @index INT = 0;
	  WHILE JSON_VALUE(@slabData, '$[' + CAST(@index AS NVARCHAR(MAX)) + '].ItemId') IS NOT NULL
    BEGIN
        -- Get the element from the JSON array using the index
        SET @slabItem = JSON_QUERY(@slabData, '$[' + CAST(@index AS NVARCHAR(MAX)) + ']');

        -- Insert into mapping table
        INSERT INTO dbo.tbl_purchaseorder_items_mappingtable (
            purchase_order_id,
            item_id,
            purchase_qty,
            purchase_price,
            subtotal,
            gsttotal,
            grandtotal
        )
        VALUES (
            @purchaseorderid,
            CAST(JSON_VALUE(@slabItem, '$.ItemId') AS int),
            CAST(JSON_VALUE(@slabItem, '$.PurchaseQty') AS int),
            CAST(JSON_VALUE(@slabItem, '$.PurchasePrice') AS decimal(18, 2)),
            CAST(JSON_VALUE(@slabItem, '$.SubTotal') AS decimal(18, 2)),
            CAST(JSON_VALUE(@slabItem, '$.GstTotal') AS decimal(18, 2)),
            CAST(JSON_VALUE(@slabItem, '$.GrandTotal') AS decimal(18, 2))
        );

        SET @index = @index + 1; -- Increment the index to process the next item
    END;
END;
GO
/****** Object:  StoredProcedure [dbo].[getallitems]    Script Date: 19-10-2023 3.06.45 PM ******/
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
/****** Object:  StoredProcedure [dbo].[getitembyid]    Script Date: 19-10-2023 3.06.45 PM ******/
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
/****** Object:  StoredProcedure [dbo].[getitembyname]    Script Date: 19-10-2023 3.06.45 PM ******/
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
