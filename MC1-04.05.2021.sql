USE [master]
GO
/****** Object:  Database [MyComp]    Script Date: 04/05/2021 7:51:20 ******/
CREATE DATABASE [MyComp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyComp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019\MSSQL\DATA\MyComp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyComp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019\MSSQL\DATA\MyComp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MyComp] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyComp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyComp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyComp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyComp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyComp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyComp] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyComp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyComp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyComp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyComp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyComp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyComp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyComp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyComp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyComp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyComp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyComp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyComp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyComp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyComp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyComp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyComp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyComp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyComp] SET RECOVERY FULL 
GO
ALTER DATABASE [MyComp] SET  MULTI_USER 
GO
ALTER DATABASE [MyComp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyComp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyComp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyComp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyComp] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MyComp', N'ON'
GO
ALTER DATABASE [MyComp] SET QUERY_STORE = OFF
GO
USE [MyComp]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 04/05/2021 7:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DeprId] [int] IDENTITY(1,1) NOT NULL,
	[DeprName] [nvarchar](100) NOT NULL,
	[DeprDescr] [nvarchar](300) NULL,
	[Status] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[DeprId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shifts]    Script Date: 04/05/2021 7:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shifts](
	[WHId] [int] IDENTITY(1,1) NOT NULL,
	[DOW] [nvarchar](100) NULL,
	[WHDateIn] [bigint] NOT NULL,
	[WHDateOut] [bigint] NOT NULL,
	[Numer] [int] NOT NULL,
	[WHTotalHours] [decimal](6, 2) NOT NULL,
	[WH100P] [decimal](6, 2) NOT NULL,
	[WH125P] [decimal](6, 2) NOT NULL,
	[WH150P] [decimal](6, 2) NOT NULL,
	[WH175P] [decimal](6, 2) NOT NULL,
	[WH200P] [decimal](6, 2) NOT NULL,
	[WrkrNumber] [int] NOT NULL,
	[IsHourly] [bit] NOT NULL,
	[HourlyPrice] [decimal](6, 2) NOT NULL,
	[TripPrice] [decimal](6, 2) NOT NULL,
	[IsGlobally] [bit] NOT NULL,
	[GloballyTotal] [decimal](10, 2) NOT NULL,
	[Status] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[WHId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workers]    Script Date: 04/05/2021 7:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workers](
	[WrkrNumber] [int] NOT NULL,
	[IDN] [nvarchar](20) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserPass] [nvarchar](100) NOT NULL,
	[IsSysAdmin] [bit] NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Phone1] [nvarchar](100) NULL,
	[Phone2] [nvarchar](100) NULL,
	[Status] [nvarchar](100) NULL,
	[IsManager] [bit] NOT NULL,
	[RolId] [int] NOT NULL,
	[DeprId] [int] NOT NULL,
	[ManagerId] [int] NOT NULL,
	[City1] [nvarchar](200) NULL,
	[Address1] [nvarchar](200) NULL,
	[BankNumber] [int] NOT NULL,
	[BnkBrnchNum] [int] NOT NULL,
	[BnkAccountNum] [nvarchar](100) NULL,
	[Gender] [nvarchar](100) NULL,
	[HourlyPrice] [decimal](6, 2) NOT NULL,
	[TripPrice] [decimal](6, 2) NOT NULL,
	[IsHourly] [bit] NOT NULL,
	[IsGlobally] [bit] NOT NULL,
	[GloballyTotal] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[WrkrNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkRoles]    Script Date: 04/05/2021 7:51:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkRoles](
	[RolId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
	[RoleDescr] [nvarchar](300) NULL,
	[Status] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[RolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 
GO
INSERT [dbo].[Departments] ([DeprId], [DeprName], [DeprDescr], [Status]) VALUES (1, N'מערכות מידע', NULL, N'Active')
GO
INSERT [dbo].[Departments] ([DeprId], [DeprName], [DeprDescr], [Status]) VALUES (2, N'תפ"י', NULL, N'Active')
GO
INSERT [dbo].[Departments] ([DeprId], [DeprName], [DeprDescr], [Status]) VALUES (3, N'מכירות', NULL, N'Active')
GO
INSERT [dbo].[Departments] ([DeprId], [DeprName], [DeprDescr], [Status]) VALUES (4, N'שיווק', NULL, N'Active')
GO
INSERT [dbo].[Departments] ([DeprId], [DeprName], [DeprDescr], [Status]) VALUES (5, N'ייצור', NULL, N'Active')
GO
INSERT [dbo].[Departments] ([DeprId], [DeprName], [DeprDescr], [Status]) VALUES (6, N'מלאי ולוגיסטיקה', NULL, N'Active')
GO
INSERT [dbo].[Departments] ([DeprId], [DeprName], [DeprDescr], [Status]) VALUES (7, N'הבטחת איכות', NULL, N'InActive')
GO
INSERT [dbo].[Departments] ([DeprId], [DeprName], [DeprDescr], [Status]) VALUES (8, N'רכש', NULL, N'Active')
GO
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100524, N'212121', N'Full Name 1', N'FN1', N'fn1', 0, N'FN1@gmail.com', N'1', N'1', N'Active', 1, 0, 0, 100720, N'City23', N'Adrs 111', 11, 110, N'111111', NULL, CAST(32.00 AS Decimal(6, 2)), CAST(15.10 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100538, N'212122', N'Full Name 2', N'FN2', N'fn2', 0, N'FN2@gmail.com', N'2', N'2', N'InActive', 0, 0, 0, 0, N'City24', N'Adrs 112', 22, 120, N'111222', NULL, CAST(32.20 AS Decimal(6, 2)), CAST(15.20 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100552, N'212121', N'Full Name 3', N'FN3', N'fn3', 0, N'FN3@gmail.com', N'3', N'3', N'InActive', 0, 0, 0, 0, N'City25', N'Adrs 113', 33, 130, N'111333', NULL, CAST(32.40 AS Decimal(6, 2)), CAST(15.30 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100566, N'212121', N'Full Name 4', N'FN4', N'fn4', 0, N'FN4@gmail.com', N'4', N'4', N'InActive', 0, 0, 0, 0, N'City26', N'Adrs 114', 44, 140, N'111444', NULL, CAST(32.60 AS Decimal(6, 2)), CAST(15.40 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100580, N'212121', N'Full Name 5', N'FN5', N'fn5', 0, N'FN5@gmail.com', N'5', N'5', N'InActive', 0, 0, 0, 0, N'City27', N'Adrs 115', 55, 150, N'111555', NULL, CAST(32.80 AS Decimal(6, 2)), CAST(15.50 AS Decimal(6, 2)), 0, 1, CAST(7840.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100594, N'212121', N'Full Name 6', N'FN6', N'fn6', 0, N'FN6@gmail.com', N'6', N'6', N'InActive', 1, 0, 0, 0, N'City28', N'Adrs 116', 66, 160, N'111666', NULL, CAST(33.00 AS Decimal(6, 2)), CAST(15.60 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100608, N'212121', N'Full Name 7', N'FN7', N'fn7', 0, N'FN7@gmail.com', N'7', N'7', N'InActive', 0, 3, 0, 0, N'City29', N'Adrs 117', 77, 170, N'111777', NULL, CAST(33.20 AS Decimal(6, 2)), CAST(15.70 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100622, N'212121', N'Full Name 8', N'FN8', N'fn8', 0, N'FN8@gmail.com', N'8', N'8', N'Active', 0, 3, 2, 100720, N'City30', N'Adrs 118', 88, 180, N'111888', N'Male', CAST(33.40 AS Decimal(6, 2)), CAST(15.80 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100636, N'212121', N'Full Name 9', N'FN9', N'fn9', 0, N'FN9@gmail.com', N'9', N'9', N'Active', 0, 0, 0, 0, N'City31', N'Adrs 119', 99, 190, N'111999', NULL, CAST(33.60 AS Decimal(6, 2)), CAST(15.90 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100650, N'212121', N'Full Name 10', N'FN10', N'fn10', 0, N'FN10@gmail.com', N'10', N'10', N'Active', 1, 0, 0, 0, N'City32', N'Adrs 120', 110, 200, N'112110', NULL, CAST(33.80 AS Decimal(6, 2)), CAST(16.00 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100664, N'212121', N'Full Name 11', N'FN11', N'fn11', 0, N'FN11@gmail.com', N'11', N'11', N'Active', 0, 0, 0, 0, N'City33', N'Adrs 121', 121, 210, N'112221', NULL, CAST(34.00 AS Decimal(6, 2)), CAST(16.10 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100678, N'212121', N'Full Name 12', N'FN12', N'fn12', 0, N'FN12@gmail.com', N'12', N'12', N'Active', 0, 0, 0, 0, N'City34', N'Adrs 122', 132, 220, N'112332', NULL, CAST(34.20 AS Decimal(6, 2)), CAST(16.20 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100692, N'212121', N'Full Name 13', N'FN13', N'fn13', 1, N'FN13@gmail.com', N'13', N'13', N'Active', 0, 0, 0, 0, N'City35', N'Adrs 123', 143, 230, N'112443', NULL, CAST(34.40 AS Decimal(6, 2)), CAST(16.30 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100706, N'212121', N'Full Name 14', N'FN14', N'fn14', 0, N'FN14@gmail.com', N'14', N'14', N'Active', 0, 0, 0, 0, N'City36', N'Adrs 124', 154, 240, N'112554', NULL, CAST(34.60 AS Decimal(6, 2)), CAST(16.40 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100720, N'212121', N'Full Name 15', N'FN15', N'fn15', 0, N'FN15@gmail.com', N'15', N'15', N'Active', 1, 0, 0, 100524, N'City37', N'Adrs 125', 165, 250, N'112665', NULL, CAST(34.80 AS Decimal(6, 2)), CAST(16.50 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100734, N'029212107', N'Full Name 17', N'FN17', N'fn17', 0, N'FN17@gmail.com', N'17', N'17', N'Active', 0, 0, 0, 100524, N'City38', N'Adrs 126', 187, 270, N'112887', NULL, CAST(35.20 AS Decimal(6, 2)), CAST(16.70 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100748, N'212121', N'Full Name 18', N'FN18', N'fn18', 0, N'FN18@gmail.com', N'18', N'18', N'InActive', 0, 0, 0, 100524, N'City39', N'Adrs 127', 198, 280, N'112998', NULL, CAST(35.40 AS Decimal(6, 2)), CAST(16.80 AS Decimal(6, 2)), 0, 1, CAST(123456.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100762, N'212121', N'Full Name 19', N'FN19', N'fn19', 0, N'FN19@gmail.com', N'19', N'19', N'InActive', 1, 0, 0, 100524, N'City40', N'Adrs 128', 209, 290, N'113109', NULL, CAST(35.60 AS Decimal(6, 2)), CAST(16.90 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100776, N'000000000', N'Full Name 20', N'FN20', N'fn20', 0, N'FN20@gmail.com', N'20', N'20', N'InActive', 1, 3, 3, 100650, N'City41', N'Adrs 129', 220, 300, N'113220', NULL, CAST(35.80 AS Decimal(6, 2)), CAST(17.00 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100790, N'212121', N'Full Name 21', N'FN21', N'fn21', 0, N'FN21@gmail.com', N'21', N'21', N'Active', 0, 0, 0, 0, N'City42', N'Adrs 130', 231, 310, N'113331', NULL, CAST(36.00 AS Decimal(6, 2)), CAST(17.10 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100804, N'212121', N'Full Name 22', N'FN22', N'fn22', 0, N'FN22@gmail.com', N'22', N'22', N'Active', 0, 0, 0, 0, N'City43', N'Adrs 131', 242, 320, N'113442', NULL, CAST(36.20 AS Decimal(6, 2)), CAST(17.20 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100814, N'029212107', N'a1', N'a1', N'a1', 0, N'a1', N'0545772386', N'', N'Active', 0, 2, 2, 100650, NULL, NULL, 0, 0, NULL, N'Male', CAST(40.00 AS Decimal(6, 2)), CAST(20.00 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
INSERT [dbo].[Workers] ([WrkrNumber], [IDN], [FullName], [UserName], [UserPass], [IsSysAdmin], [Email], [Phone1], [Phone2], [Status], [IsManager], [RolId], [DeprId], [ManagerId], [City1], [Address1], [BankNumber], [BnkBrnchNum], [BnkAccountNum], [Gender], [HourlyPrice], [TripPrice], [IsHourly], [IsGlobally], [GloballyTotal]) VALUES (100824, N'029212107', N'חמזה אבו חלא', N'HMZ', N'1', 0, N'hamziak@gmail.com', N'0545772386', N'', N'InActive', 1, 5, 1, 100650, NULL, NULL, 111, 222, N'333', N'Male', CAST(125.00 AS Decimal(6, 2)), CAST(12.00 AS Decimal(6, 2)), 1, 0, CAST(0.00 AS Decimal(10, 2)))
GO
SET IDENTITY_INSERT [dbo].[WorkRoles] ON 
GO
INSERT [dbo].[WorkRoles] ([RolId], [RoleName], [RoleDescr], [Status]) VALUES (1, N'מפעיל/ה', NULL, N'Active')
GO
INSERT [dbo].[WorkRoles] ([RolId], [RoleName], [RoleDescr], [Status]) VALUES (2, N'אחראי/ת משמרת', NULL, N'Active')
GO
INSERT [dbo].[WorkRoles] ([RolId], [RoleName], [RoleDescr], [Status]) VALUES (3, N'מזכיר/ה', NULL, N'Active')
GO
INSERT [dbo].[WorkRoles] ([RolId], [RoleName], [RoleDescr], [Status]) VALUES (4, N'מנהל/ת מחלקה', NULL, N'Active')
GO
INSERT [dbo].[WorkRoles] ([RolId], [RoleName], [RoleDescr], [Status]) VALUES (5, N'ראש צוות', NULL, N'Active')
GO
INSERT [dbo].[WorkRoles] ([RolId], [RoleName], [RoleDescr], [Status]) VALUES (6, N'עובד/ת רגיל/ה', NULL, N'Active')
GO
INSERT [dbo].[WorkRoles] ([RolId], [RoleName], [RoleDescr], [Status]) VALUES (7, N'test', NULL, N'InActive')
GO
SET IDENTITY_INSERT [dbo].[WorkRoles] OFF
GO
ALTER TABLE [dbo].[Shifts] ADD  DEFAULT (' ') FOR [DOW]
GO
ALTER TABLE [dbo].[Shifts] ADD  DEFAULT ((0)) FOR [WHDateIn]
GO
ALTER TABLE [dbo].[Shifts] ADD  DEFAULT ((0)) FOR [WHDateOut]
GO
ALTER TABLE [dbo].[Shifts] ADD  DEFAULT ((0)) FOR [Numer]
GO
ALTER TABLE [dbo].[Shifts] ADD  DEFAULT ((0)) FOR [WHTotalHours]
GO
ALTER TABLE [dbo].[Shifts] ADD  DEFAULT ((0)) FOR [WH100P]
GO
ALTER TABLE [dbo].[Shifts] ADD  DEFAULT ((0)) FOR [WH125P]
GO
ALTER TABLE [dbo].[Shifts] ADD  DEFAULT ((0)) FOR [WH150P]
GO
ALTER TABLE [dbo].[Shifts] ADD  DEFAULT ((0)) FOR [WH175P]
GO
ALTER TABLE [dbo].[Shifts] ADD  DEFAULT ((0)) FOR [WH200P]
GO
ALTER TABLE [dbo].[Shifts] ADD  DEFAULT ((0)) FOR [WrkrNumber]
GO
ALTER TABLE [dbo].[Shifts] ADD  DEFAULT ((0)) FOR [IsHourly]
GO
ALTER TABLE [dbo].[Shifts] ADD  DEFAULT ((0)) FOR [HourlyPrice]
GO
ALTER TABLE [dbo].[Shifts] ADD  DEFAULT ((0)) FOR [TripPrice]
GO
ALTER TABLE [dbo].[Shifts] ADD  DEFAULT ((0)) FOR [IsGlobally]
GO
ALTER TABLE [dbo].[Shifts] ADD  DEFAULT ((0)) FOR [GloballyTotal]
GO
ALTER TABLE [dbo].[Workers] ADD  DEFAULT (' ') FOR [IDN]
GO
ALTER TABLE [dbo].[Workers] ADD  DEFAULT ((0)) FOR [IsSysAdmin]
GO
ALTER TABLE [dbo].[Workers] ADD  DEFAULT ((0)) FOR [IsManager]
GO
ALTER TABLE [dbo].[Workers] ADD  DEFAULT ((0)) FOR [RolId]
GO
ALTER TABLE [dbo].[Workers] ADD  DEFAULT ((0)) FOR [DeprId]
GO
ALTER TABLE [dbo].[Workers] ADD  DEFAULT ((0)) FOR [ManagerId]
GO
ALTER TABLE [dbo].[Workers] ADD  DEFAULT ((0)) FOR [BankNumber]
GO
ALTER TABLE [dbo].[Workers] ADD  DEFAULT ((0)) FOR [BnkBrnchNum]
GO
ALTER TABLE [dbo].[Workers] ADD  DEFAULT ((0)) FOR [HourlyPrice]
GO
ALTER TABLE [dbo].[Workers] ADD  DEFAULT ((0)) FOR [TripPrice]
GO
ALTER TABLE [dbo].[Workers] ADD  DEFAULT ((0)) FOR [IsHourly]
GO
ALTER TABLE [dbo].[Workers] ADD  DEFAULT ((0)) FOR [IsGlobally]
GO
ALTER TABLE [dbo].[Workers] ADD  DEFAULT ((0)) FOR [GloballyTotal]
GO
USE [master]
GO
ALTER DATABASE [MyComp] SET  READ_WRITE 
GO
