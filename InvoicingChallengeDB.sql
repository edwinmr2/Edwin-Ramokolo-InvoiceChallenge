USE [master]
GO
/****** Object:  Database [InvoicingChallengeDB]    Script Date: 9/9/2022 3:22:36 PM ******/
CREATE DATABASE [InvoicingChallengeDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InvoicingChallengeDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\InvoicingChallengeDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InvoicingChallengeDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\InvoicingChallengeDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [InvoicingChallengeDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InvoicingChallengeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InvoicingChallengeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InvoicingChallengeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InvoicingChallengeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InvoicingChallengeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InvoicingChallengeDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [InvoicingChallengeDB] SET  MULTI_USER 
GO
ALTER DATABASE [InvoicingChallengeDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InvoicingChallengeDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InvoicingChallengeDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InvoicingChallengeDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InvoicingChallengeDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InvoicingChallengeDB] SET QUERY_STORE = OFF
GO
USE [InvoicingChallengeDB]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 9/9/2022 3:22:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[BillToName] [nvarchar](50) NULL,
	[StreetAddress] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[ZipCode] [nchar](10) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorMessages]    Script Date: 9/9/2022 3:22:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorMessages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[Datetime] [datetime] NULL,
 CONSTRAINT [PK_ErrorMessages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GlobalValues]    Script Date: 9/9/2022 3:22:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GlobalValues](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_GlobalValues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceLineItems]    Script Date: 9/9/2022 3:22:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceLineItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[Quantity] [int] NULL,
	[Amount] [decimal](18, 0) NULL,
	[IsTaxed] [bit] NULL,
 CONSTRAINT [PK_InvoiceLineItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 9/9/2022 3:22:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateOfInvoice] [datetime] NULL,
	[CustomerId] [int] NULL,
	[DueDate] [datetime] NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[SubTotal] [decimal](18, 2) NULL,
	[Taxable] [decimal](18, 2) NULL,
	[TaxDue] [decimal](18, 2) NULL,
	[Other] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductServices]    Script Date: 9/9/2022 3:22:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductServices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Amount] [decimal](18, 0) NULL,
	[IsTaxed] [bit] NULL,
 CONSTRAINT [PK_ProductServices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[GlobalValues] ON 

INSERT [dbo].[GlobalValues] ([Id], [Name], [Value]) VALUES (1, N'TaxRate', N'6.25')
INSERT [dbo].[GlobalValues] ([Id], [Name], [Value]) VALUES (2, N'CompanyName', N'Edwin LLC')
INSERT [dbo].[GlobalValues] ([Id], [Name], [Value]) VALUES (3, N'CompanyAddressLine', N'742 Ebony Str')
INSERT [dbo].[GlobalValues] ([Id], [Name], [Value]) VALUES (4, N'City', N'Johanesburg')
INSERT [dbo].[GlobalValues] ([Id], [Name], [Value]) VALUES (5, N'State', N'South Africa')
INSERT [dbo].[GlobalValues] ([Id], [Name], [Value]) VALUES (6, N'ZipCode', N'1962')
INSERT [dbo].[GlobalValues] ([Id], [Name], [Value]) VALUES (7, N'FaxNumber', N'0118521485')
INSERT [dbo].[GlobalValues] ([Id], [Name], [Value]) VALUES (8, N'TelphoneNumber', N'0118525621')
INSERT [dbo].[GlobalValues] ([Id], [Name], [Value]) VALUES (9, N'EnquiresEmail', N'enquires@text.com')
INSERT [dbo].[GlobalValues] ([Id], [Name], [Value]) VALUES (1002, N'Website', N'www.test.co.za')
SET IDENTITY_INSERT [dbo].[GlobalValues] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceLineItems] ON 

INSERT [dbo].[InvoiceLineItems] ([Id], [InvoiceId], [Description], [Quantity], [Amount], [IsTaxed]) VALUES (16, 22, N'Service Fee Quantity: 1', 1, CAST(150 AS Decimal(18, 0)), 0)
INSERT [dbo].[InvoiceLineItems] ([Id], [InvoiceId], [Description], [Quantity], [Amount], [IsTaxed]) VALUES (17, 22, N'Service Labour Quantity: 5', 1, CAST(2500 AS Decimal(18, 0)), 0)
INSERT [dbo].[InvoiceLineItems] ([Id], [InvoiceId], [Description], [Quantity], [Amount], [IsTaxed]) VALUES (18, 22, N'Product 2 Quantity: 20', 1, CAST(5000 AS Decimal(18, 0)), 1)
INSERT [dbo].[InvoiceLineItems] ([Id], [InvoiceId], [Description], [Quantity], [Amount], [IsTaxed]) VALUES (19, 23, N'Service Fee Quantity: 1', 1, CAST(150 AS Decimal(18, 0)), 0)
INSERT [dbo].[InvoiceLineItems] ([Id], [InvoiceId], [Description], [Quantity], [Amount], [IsTaxed]) VALUES (20, 23, N'Product 4 Quantity: 40', 1, CAST(48000 AS Decimal(18, 0)), 1)
INSERT [dbo].[InvoiceLineItems] ([Id], [InvoiceId], [Description], [Quantity], [Amount], [IsTaxed]) VALUES (21, 24, N'Service Fee Quantity: 3', 3, CAST(450 AS Decimal(18, 0)), 0)
INSERT [dbo].[InvoiceLineItems] ([Id], [InvoiceId], [Description], [Quantity], [Amount], [IsTaxed]) VALUES (22, 24, N'Product 1 Quantity: 5', 3, CAST(250 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[InvoiceLineItems] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductServices] ON 

INSERT [dbo].[ProductServices] ([Id], [Name], [Amount], [IsTaxed]) VALUES (1, N'Service Labour', CAST(500 AS Decimal(18, 0)), 0)
INSERT [dbo].[ProductServices] ([Id], [Name], [Amount], [IsTaxed]) VALUES (2, N'Service Fee', CAST(150 AS Decimal(18, 0)), 0)
INSERT [dbo].[ProductServices] ([Id], [Name], [Amount], [IsTaxed]) VALUES (3, N'Product 1', CAST(50 AS Decimal(18, 0)), 1)
INSERT [dbo].[ProductServices] ([Id], [Name], [Amount], [IsTaxed]) VALUES (4, N'Product 2', CAST(250 AS Decimal(18, 0)), 1)
INSERT [dbo].[ProductServices] ([Id], [Name], [Amount], [IsTaxed]) VALUES (5, N'Product 3', CAST(300 AS Decimal(18, 0)), 1)
INSERT [dbo].[ProductServices] ([Id], [Name], [Amount], [IsTaxed]) VALUES (6, N'Product 4', CAST(1200 AS Decimal(18, 0)), 1)
INSERT [dbo].[ProductServices] ([Id], [Name], [Amount], [IsTaxed]) VALUES (7, N'Product 5', CAST(800 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[ProductServices] OFF
GO
USE [master]
GO
ALTER DATABASE [InvoicingChallengeDB] SET  READ_WRITE 
GO
