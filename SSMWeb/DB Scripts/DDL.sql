USE [master]
GO
/****** Object:  Database [SSM]    Script Date: 7/17/2015 3:58:18 PM ******/
CREATE DATABASE [SSM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SSM', FILENAME = N'C:\Users\Erdem\SSM_yeni.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SSM_log', FILENAME = N'C:\Users\Erdem\SSM_log_yeni.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SSM] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SSM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SSM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SSM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SSM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SSM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SSM] SET ARITHABORT OFF 
GO
ALTER DATABASE [SSM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SSM] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SSM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SSM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SSM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SSM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SSM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SSM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SSM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SSM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SSM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SSM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SSM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SSM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SSM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SSM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SSM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SSM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SSM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SSM] SET  MULTI_USER 
GO
ALTER DATABASE [SSM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SSM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SSM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SSM] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SSM]
GO
/****** Object:  Table [dbo].[Barcodes]    Script Date: 7/17/2015 3:58:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Barcodes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CodeNumber] [nvarchar](max) NOT NULL,
	[CodeType] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Barcodes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Boxes]    Script Date: 7/17/2015 3:58:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boxes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BarcodeId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[PartCapOfBox] [nvarchar](max) NOT NULL,
	[PartQtyUnitID] [nvarchar](max) NOT NULL,
	[PartQtyLeft] [nvarchar](max) NOT NULL,
	[BoxUnitOfTotal] [nvarchar](max) NOT NULL,
	[BoxTotalOfTotal] [nvarchar](max) NOT NULL,
	[PONumber] [nvarchar](max) NOT NULL,
	[BoxBrcdID] [nvarchar](max) NOT NULL,
	[LocationID] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[DeliveryId] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Boxes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[COGS]    Script Date: 7/17/2015 3:58:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COGS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UnitPrice] [nvarchar](max) NULL,
	[PartQtyUnitID] [nvarchar](max) NULL,
	[SetPrice] [nvarchar](max) NULL,
 CONSTRAINT [PK_COGS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Deliveries]    Script Date: 7/17/2015 3:58:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deliveries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[ShipmentId] [int] NOT NULL,
 CONSTRAINT [PK_Deliveries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeliveryLists]    Script Date: 7/17/2015 3:58:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryLists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [nvarchar](max) NULL,
	[BoxQuantiy] [nvarchar](max) NULL,
	[PartCapOfBox] [nvarchar](max) NULL,
	[DeliveryId] [int] NOT NULL,
 CONSTRAINT [PK_DeliveryLists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FulfilmentSKUs]    Script Date: 7/17/2015 3:58:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FulfilmentSKUs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SKU] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[SCName] [nvarchar](max) NULL,
	[ASIN] [nvarchar](max) NULL,
	[IsDiscontinued] [bit] NULL DEFAULT ((0)),
 CONSTRAINT [PK_FulfilmentSKUs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Locations]    Script Date: 7/17/2015 3:58:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderLists]    Script Date: 7/17/2015 3:58:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderLists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderName] [nvarchar](max) NOT NULL,
	[SoldDate] [datetime] NOT NULL,
	[SalesChannel] [nvarchar](max) NOT NULL,
	[BoxId] [nvarchar](max) NOT NULL,
	[SoldQty] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_OrderLists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 7/17/2015 3:58:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderName] [nvarchar](max) NOT NULL,
	[SoldDate] [datetime] NOT NULL,
	[SalesChannel] [nvarchar](max) NOT NULL,
	[OrderListId] [int] NOT NULL,
	[OrderAmount] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductCategories]    Script Date: 7/17/2015 3:58:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Aliases] [nvarchar](max) NULL,
	[IsEnabled] [bit] NULL DEFAULT ((1)),
 CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductColors]    Script Date: 7/17/2015 3:58:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductColors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Aliases] [nvarchar](max) NULL,
	[IsEnabled] [bit] NULL DEFAULT ((1)),
 CONSTRAINT [PK_ProductColors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 7/17/2015 3:58:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SKU] [nvarchar](max) NULL,
	[FulfilmentSKUId] [int] NOT NULL,
	[Aliases] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[ParentId] [bigint] NULL,
	[IsDiscontinued] [bit] NULL DEFAULT ((0)),
	[CategoryId] [int] NOT NULL,
	[ColorId] [int] NOT NULL,
	[SizeId] [int] NOT NULL,
	[PartQtyUnitID] [int] NOT NULL,
	[COGSId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductSizes]    Script Date: 7/17/2015 3:58:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSizes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Dimentions] [nvarchar](max) NULL,
	[Property1] [nvarchar](max) NULL,
	[IsEnabled] [bit] NULL DEFAULT ((1)),
 CONSTRAINT [PK_ProductSizes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuantityUnits]    Script Date: 7/17/2015 3:58:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuantityUnits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_QuantityUnits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ShipmentLists]    Script Date: 7/17/2015 3:58:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShipmentLists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[BoxCapacity] [nvarchar](max) NULL,
	[BoxQuantity] [nvarchar](max) NULL,
	[ShipmentId] [int] NOT NULL,
 CONSTRAINT [PK_ShipmentLists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Shipments]    Script Date: 7/17/2015 3:58:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedUserId] [nvarchar](max) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedUserId] [nvarchar](max) NULL,
	[LoadedDate] [datetime] NULL,
	[ContainerName] [nvarchar](max) NULL,
	[PONumber] [nvarchar](max) NULL,
	[BoxQuantity] [bigint] NULL,
	[DestinationCity] [nvarchar](max) NULL,
	[ETD] [datetime] NULL,
	[ContainerType] [nvarchar](max) NULL,
	[PickupReferanceID] [nvarchar](max) NULL,
	[VesselName] [nvarchar](max) NULL,
	[FreightCompany] [nvarchar](max) NULL,
	[IsAirShipment] [bit] NULL DEFAULT ((0)),
	[IsCustomsCleared] [bit] NULL DEFAULT ((0)),
	[IsDelivered] [bit] NULL DEFAULT ((0)),
	[IsCustomsPaid] [bit] NULL DEFAULT ((0)),
	[IsFreightPaid] [bit] NULL DEFAULT ((0)),
	[CustomsAmount] [float] NULL,
	[FreightAmount] [float] NULL,
	[HandlingFeeAmount] [float] NULL,
 CONSTRAINT [PK_Shipments2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_FK_BarcodesBoxes]    Script Date: 7/17/2015 3:58:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_BarcodesBoxes] ON [dbo].[Boxes]
(
	[BarcodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_LocationBoxes]    Script Date: 7/17/2015 3:58:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_LocationBoxes] ON [dbo].[Boxes]
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_OrderBoxes]    Script Date: 7/17/2015 3:58:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_OrderBoxes] ON [dbo].[Boxes]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ProductsBoxes]    Script Date: 7/17/2015 3:58:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_ProductsBoxes] ON [dbo].[Boxes]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_DeliveryDeliveryList]    Script Date: 7/17/2015 3:58:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_DeliveryDeliveryList] ON [dbo].[DeliveryLists]
(
	[DeliveryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_OrderListOrder]    Script Date: 7/17/2015 3:58:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_OrderListOrder] ON [dbo].[Orders]
(
	[OrderListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_COGSProducts]    Script Date: 7/17/2015 3:58:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_COGSProducts] ON [dbo].[Products]
(
	[COGSId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_FulfilmentSKUProducts]    Script Date: 7/17/2015 3:58:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_FulfilmentSKUProducts] ON [dbo].[Products]
(
	[FulfilmentSKUId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ProductCategoryProducts]    Script Date: 7/17/2015 3:58:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_ProductCategoryProducts] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ProductColorProducts]    Script Date: 7/17/2015 3:58:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_ProductColorProducts] ON [dbo].[Products]
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ProductSizeProducts]    Script Date: 7/17/2015 3:58:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_ProductSizeProducts] ON [dbo].[Products]
(
	[SizeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_QuantityUnitProducts]    Script Date: 7/17/2015 3:58:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_QuantityUnitProducts] ON [dbo].[Products]
(
	[PartQtyUnitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ProductsShipmentList]    Script Date: 7/17/2015 3:58:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_ProductsShipmentList] ON [dbo].[ShipmentLists]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ShipmentsShipmentList]    Script Date: 7/17/2015 3:58:18 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_ShipmentsShipmentList] ON [dbo].[ShipmentLists]
(
	[ShipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Locations] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Boxes]  WITH CHECK ADD  CONSTRAINT [FK_BarcodesBoxes] FOREIGN KEY([BarcodeId])
REFERENCES [dbo].[Barcodes] ([Id])
GO
ALTER TABLE [dbo].[Boxes] CHECK CONSTRAINT [FK_BarcodesBoxes]
GO
ALTER TABLE [dbo].[Boxes]  WITH CHECK ADD  CONSTRAINT [FK_LocationBoxes] FOREIGN KEY([LocationID])
REFERENCES [dbo].[Locations] ([Id])
GO
ALTER TABLE [dbo].[Boxes] CHECK CONSTRAINT [FK_LocationBoxes]
GO
ALTER TABLE [dbo].[Boxes]  WITH CHECK ADD  CONSTRAINT [FK_OrderBoxes] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[Boxes] CHECK CONSTRAINT [FK_OrderBoxes]
GO
ALTER TABLE [dbo].[Boxes]  WITH CHECK ADD  CONSTRAINT [FK_ProductsBoxes] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Boxes] CHECK CONSTRAINT [FK_ProductsBoxes]
GO
ALTER TABLE [dbo].[DeliveryLists]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryDeliveryList] FOREIGN KEY([DeliveryId])
REFERENCES [dbo].[Deliveries] ([Id])
GO
ALTER TABLE [dbo].[DeliveryLists] CHECK CONSTRAINT [FK_DeliveryDeliveryList]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_OrderListOrder] FOREIGN KEY([OrderListId])
REFERENCES [dbo].[OrderLists] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_OrderListOrder]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_COGSProducts] FOREIGN KEY([COGSId])
REFERENCES [dbo].[COGS] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_COGSProducts]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_FulfilmentSKUProducts] FOREIGN KEY([FulfilmentSKUId])
REFERENCES [dbo].[FulfilmentSKUs] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_FulfilmentSKUProducts]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategoriesProducts] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ProductCategories] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_ProductCategoriesProducts]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_ProductColorProducts] FOREIGN KEY([ColorId])
REFERENCES [dbo].[ProductColors] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_ProductColorProducts]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_ProductSizeProducts] FOREIGN KEY([SizeId])
REFERENCES [dbo].[ProductSizes] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_ProductSizeProducts]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_QuantityUnitProducts] FOREIGN KEY([PartQtyUnitID])
REFERENCES [dbo].[QuantityUnits] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_QuantityUnitProducts]
GO
ALTER TABLE [dbo].[ShipmentLists]  WITH CHECK ADD  CONSTRAINT [FK_ProductsShipmentList] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ShipmentLists] CHECK CONSTRAINT [FK_ProductsShipmentList]
GO
ALTER TABLE [dbo].[ShipmentLists]  WITH CHECK ADD  CONSTRAINT [FK_ShipmentsShipmentLists] FOREIGN KEY([ShipmentId])
REFERENCES [dbo].[Shipments] ([Id])
GO
ALTER TABLE [dbo].[ShipmentLists] CHECK CONSTRAINT [FK_ShipmentsShipmentLists]
GO
USE [master]
GO
ALTER DATABASE [SSM] SET  READ_WRITE 
GO


  create TRIGGER ShipmentDelivered
  ON [dbo].[Shipments]
  FOR UPDATE AS 

  IF UPDATE(IsDelivered)
  BEGIN
	INSERT INTO [dbo].[Deliveries] ([Date],[ShipmentId]) 
		SELECT GETDATE(),Id FROM inserted WHERE IsDelivered = 1

	INSERT INTO [dbo].[DeliveryLists] ([ProductId],[BoxQuantiy],[PartCapOfBox],[DeliveryId]) 
		SELECT s.[ProductId],s.[BoxQuantity],s.[BoxCapacity],d.[Id] FROM [dbo].[ShipmentLists] s, [dbo].[Deliveries] d
			WHERE s.ShipmentId = (SELECT Id FROM inserted WHERE IsDelivered = 1)
					AND s.ShipmentId = d.ShipmentId
  END

  GO

   
	CREATE TRIGGER ShipmentDeliveredCancel
  ON [dbo].[Shipments]
  FOR UPDATE AS 

  IF UPDATE(IsDelivered)
  BEGIN
  DELETE FROM [dbo].[DeliveryLists] WHERE [DeliveryId] =  (SELECT Id FROM [dbo].[Deliveries] WHERE [ShipmentId] =  (SELECT Id FROM inserted WHERE IsDelivered = 0))
  DELETE FROM [dbo].[Deliveries] WHERE [ShipmentId] =  (SELECT Id FROM inserted WHERE IsDelivered = 0)
  END


  GO