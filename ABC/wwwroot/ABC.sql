USE [master]
GO
/****** Object:  Database [ABC]    Script Date: 7/14/2021 10:34:42 AM ******/
CREATE DATABASE [ABC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ABC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ABC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ABC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ABC_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ABC] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ABC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ABC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ABC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ABC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ABC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ABC] SET ARITHABORT OFF 
GO
ALTER DATABASE [ABC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ABC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ABC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ABC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ABC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ABC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ABC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ABC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ABC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ABC] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ABC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ABC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ABC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ABC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ABC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ABC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ABC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ABC] SET RECOVERY FULL 
GO
ALTER DATABASE [ABC] SET  MULTI_USER 
GO
ALTER DATABASE [ABC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ABC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ABC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ABC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ABC] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ABC', N'ON'
GO
ALTER DATABASE [ABC] SET QUERY_STORE = OFF
GO
USE [ABC]
GO
/****** Object:  Table [dbo].[ApplicationExceptions]    Script Date: 7/14/2021 10:34:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationExceptions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ErrorMessage] [nvarchar](max) NULL,
	[InnerException] [nvarchar](max) NULL,
	[StackTrace] [nvarchar](max) NULL,
	[LoggedInUser] [nvarchar](50) NULL,
	[DateTime] [datetime] NULL,
 CONSTRAINT [PK_ApplicationExceptions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationUser]    Script Date: 7/14/2021 10:34:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreationDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModificationDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[Address] [nvarchar](max) NULL,
	[RegId] [nvarchar](max) NULL,
 CONSTRAINT [PK_ApplicationUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Complaint]    Script Date: 7/14/2021 10:34:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Complaint](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ComplaintDate] [datetime] NOT NULL,
	[ComplainerName] [nvarchar](50) NOT NULL,
	[ComplainerEmail] [nvarchar](50) NOT NULL,
	[ComplaintLocation] [nvarchar](50) NOT NULL,
	[ComplaintDetails] [nvarchar](max) NOT NULL,
	[DesiredOutcome] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
	[NoPromotion] [bit] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreationDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_Complaint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComplaintNature]    Script Date: 7/14/2021 10:34:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComplaintNature](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ComplaintId] [int] NOT NULL,
	[ComplaintNatueId] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreationDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [PK_ComplaintNature] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LookUpsDetails]    Script Date: 7/14/2021 10:34:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LookUpsDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MasterCode] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Value] [int] NOT NULL,
	[OrderNumber] [int] NOT NULL,
 CONSTRAINT [PK_LookUpsDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LookUpsMaster]    Script Date: 7/14/2021 10:34:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LookUpsMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LookUpsMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleClaims]    Script Date: 7/14/2021 10:34:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 7/14/2021 10:34:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 7/14/2021 10:34:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 7/14/2021 10:34:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 7/14/2021 10:34:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 7/14/2021 10:34:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[UserId] [int] NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ApplicationExceptions] ON 

GO
SET IDENTITY_INSERT [dbo].[ApplicationExceptions] OFF
GO
SET IDENTITY_INSERT [dbo].[ApplicationUser] ON 
GO
INSERT [dbo].[ApplicationUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [IsActive], [Address], [RegId]) VALUES (2, N'Admin', N'ADMIN', N'H.Altabakhi@outlook.com', N'H.ALTABAKHI@OUTLOOK.COM', 0, N'AQAAAAEAACcQAAAAELbRNW7mw/4iZpuxPsgcSW1h8jpJHmHZ2ZthjJ29y1Fo7xh7opMumpxEzrBfz+mxSw==', N'UN5FKSONYGVM6FOU6KTWNKVJMDXXU6QU', N'b805d6a4-171d-4ac2-9a9d-05d32e772555', N'0790807404', 0, 0, NULL, 1, 0, N'Hamza Mohammad Altabakhi', N'Admin', CAST(N'2021-07-12T02:18:00.353' AS DateTime), NULL, NULL, 1, N'Amman', NULL)
GO
INSERT [dbo].[ApplicationUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [IsActive], [Address], [RegId]) VALUES (7, N'Client1', N'CLIENT1', N'client1@gmail.com', N'CLIENT1@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEAbCcvUGWg32HB91jEQBf3VjxiBmNqmChmsEcudL0GDt3dK+ykrA78ytQ6XvbRQ3sQ==', N'2NAU5RHVI5IJA2IS4U5V6AHRNQATCNC6', N'85b04915-1ec5-46e7-ac24-77b97d5cd29a', N'0790807404', 0, 0, NULL, 1, 0, N'Client 1', N'Client1', CAST(N'2021-07-14T08:50:35.850' AS DateTime), NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[ApplicationUser] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FullName], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate], [IsActive], [Address], [RegId]) VALUES (8, N'Client2', N'CLIENT2', N'Client2@gmail.com', N'CLIENT2@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEN0orWZbGPQCG9+nTaQ1pBKHQ++kmFPJzOe8KGRLfe8bsCKN3x5Vj41x4KPOU4Scog==', N'WFLOLZPYVDC5WKPLAPX7S3CFAG4H3DFS', N'74449bb0-02fe-491e-968c-ae69507a7782', N'0790790790', 0, 0, NULL, 1, 0, N'Client 2', N'Client2', CAST(N'2021-07-14T09:00:48.243' AS DateTime), NULL, NULL, 1, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[ApplicationUser] OFF
GO
SET IDENTITY_INSERT [dbo].[Complaint] ON 
GO
INSERT [dbo].[Complaint] ([Id], [ComplaintDate], [ComplainerName], [ComplainerEmail], [ComplaintLocation], [ComplaintDetails], [DesiredOutcome], [Status], [NoPromotion], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate]) VALUES (9, CAST(N'2021-07-13T21:00:00.000' AS DateTime), N'client 1', N'test@test.com', N'amman', N'test details', N'test outcome', 2, 1, N'7', CAST(N'2021-07-14T08:58:47.100' AS DateTime), N'2', CAST(N'2021-07-14T09:03:31.773' AS DateTime))
GO
INSERT [dbo].[Complaint] ([Id], [ComplaintDate], [ComplainerName], [ComplainerEmail], [ComplaintLocation], [ComplaintDetails], [DesiredOutcome], [Status], [NoPromotion], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate]) VALUES (10, CAST(N'2021-07-14T21:00:00.000' AS DateTime), N'Client 2', N'Client@gmail.com', N'amman', N'test 1', N'test 2', 1, 1, N'8', CAST(N'2021-07-14T09:02:43.153' AS DateTime), NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Complaint] OFF
GO
SET IDENTITY_INSERT [dbo].[ComplaintNature] ON 
GO
INSERT [dbo].[ComplaintNature] ([Id], [ComplaintId], [ComplaintNatueId], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate]) VALUES (24, 9, 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ComplaintNature] ([Id], [ComplaintId], [ComplaintNatueId], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate]) VALUES (25, 9, 2, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ComplaintNature] ([Id], [ComplaintId], [ComplaintNatueId], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate]) VALUES (26, 9, 3, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ComplaintNature] ([Id], [ComplaintId], [ComplaintNatueId], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate]) VALUES (27, 10, 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ComplaintNature] ([Id], [ComplaintId], [ComplaintNatueId], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate]) VALUES (28, 10, 2, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ComplaintNature] ([Id], [ComplaintId], [ComplaintNatueId], [CreatedBy], [CreationDate], [ModifiedBy], [ModificationDate]) VALUES (29, 10, 3, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[ComplaintNature] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (1, N'Admin', N'Admin', NULL)
GO
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (2, N'Client', N'Client', NULL)
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (2, 1)
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (7, 2)
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (8, 2)
GO
/****** Object:  Index [UniqueCode_LookUpsMaster]    Script Date: 7/14/2021 10:34:42 AM ******/
ALTER TABLE [dbo].[LookUpsMaster] ADD  CONSTRAINT [UniqueCode_LookUpsMaster] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ComplaintNature]  WITH CHECK ADD  CONSTRAINT [FK_ComplaintNature_Complaint] FOREIGN KEY([ComplaintId])
REFERENCES [dbo].[Complaint] ([Id])
GO
ALTER TABLE [dbo].[ComplaintNature] CHECK CONSTRAINT [FK_ComplaintNature_Complaint]
GO
ALTER TABLE [dbo].[LookUpsDetails]  WITH CHECK ADD  CONSTRAINT [FK_LookUpsDetails_LookUpsDetails] FOREIGN KEY([Id])
REFERENCES [dbo].[LookUpsDetails] ([Id])
GO
ALTER TABLE [dbo].[LookUpsDetails] CHECK CONSTRAINT [FK_LookUpsDetails_LookUpsDetails]
GO
ALTER TABLE [dbo].[LookUpsDetails]  WITH CHECK ADD  CONSTRAINT [FK_LookUpsDetails_LookUpsMaster] FOREIGN KEY([MasterCode])
REFERENCES [dbo].[LookUpsMaster] ([Code])
GO
ALTER TABLE [dbo].[LookUpsDetails] CHECK CONSTRAINT [FK_LookUpsDetails_LookUpsMaster]
GO
ALTER TABLE [dbo].[RoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_RoleClaims_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleClaims] CHECK CONSTRAINT [FK_RoleClaims_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_ApplicationUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[ApplicationUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaims] CHECK CONSTRAINT [FK_UserClaims_ApplicationUser_UserId]
GO
ALTER TABLE [dbo].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_ApplicationUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[ApplicationUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_ApplicationUser_UserId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_ApplicationUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[ApplicationUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_ApplicationUser_UserId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserTokens_ApplicationUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[ApplicationUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTokens] CHECK CONSTRAINT [FK_UserTokens_ApplicationUser_UserId]
GO
USE [master]
GO
ALTER DATABASE [ABC] SET  READ_WRITE 
GO
