USE [master]
GO
/****** Object:  Database [CinemaSystem]    Script Date: 24.05.2023 23:05:19 ******/
CREATE DATABASE [CinemaSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CinemaSystem', FILENAME = N'D:\Pgs\DataBases\CinemaSystem.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CinemaSystem_log', FILENAME = N'D:\Pgs\DataBases\CinemaSystem_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CinemaSystem] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CinemaSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CinemaSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CinemaSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CinemaSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CinemaSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CinemaSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [CinemaSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CinemaSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CinemaSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CinemaSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CinemaSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CinemaSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CinemaSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CinemaSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CinemaSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CinemaSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CinemaSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CinemaSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CinemaSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CinemaSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CinemaSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CinemaSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CinemaSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CinemaSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [CinemaSystem] SET  MULTI_USER 
GO
ALTER DATABASE [CinemaSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CinemaSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CinemaSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CinemaSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CinemaSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CinemaSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CinemaSystem', N'ON'
GO
ALTER DATABASE [CinemaSystem] SET QUERY_STORE = ON
GO
ALTER DATABASE [CinemaSystem] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CinemaSystem]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 24.05.2023 23:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserPassword] [nchar](30) NOT NULL,
	[UserLogin] [nvarchar](30) NOT NULL,
	[idUser] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UserRoles]    Script Date: 24.05.2023 23:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UserRoles]
AS
SELECT UserLogin, UserPassword, CASE WHEN UserLogin = 'admin' THEN 'admin' ELSE 'user' END AS Role
FROM Users
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 24.05.2023 23:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[AdmPassword] [nchar](30) NOT NULL,
	[AdmLogin] [nchar](30) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 24.05.2023 23:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Country] [nchar](15) NOT NULL,
	[idProduction] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[idProduction] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 24.05.2023 23:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[idGenre] [int] IDENTITY(1,1) NOT NULL,
	[Genre] [nchar](20) NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[idGenre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Halls]    Script Date: 24.05.2023 23:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Halls](
	[IDhall] [int] IDENTITY(1,1) NOT NULL,
	[NameHall] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Halls] PRIMARY KEY CLUSTERED 
(
	[IDhall] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 24.05.2023 23:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[IDmovie] [int] IDENTITY(1,1) NOT NULL,
	[NameMovie] [nvarchar](50) NOT NULL,
	[Production] [int] NULL,
	[YearOfIssue] [int] NOT NULL,
	[iGenre] [int] NOT NULL,
	[Duration] [int] NOT NULL,
 CONSTRAINT [PK_Movies_1] PRIMARY KEY CLUSTERED 
(
	[IDmovie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prices]    Script Date: 24.05.2023 23:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prices](
	[IDPrice] [int] NOT NULL,
	[Price] [money] NOT NULL,
	[idHall] [int] NOT NULL,
 CONSTRAINT [PK_Price] PRIMARY KEY CLUSTERED 
(
	[IDPrice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 24.05.2023 23:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[Date] [date] NOT NULL,
	[Time] [time](0) NOT NULL,
	[Hall] [int] NOT NULL,
	[Movie] [int] NOT NULL,
	[ID_Session] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[ID_Session] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 24.05.2023 23:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[IDticket] [int] IDENTITY(1,1) NOT NULL,
	[Row] [int] NOT NULL,
	[Place] [int] NOT NULL,
	[Sold] [bit] NOT NULL,
	[Session] [int] NOT NULL,
	[idPrice] [int] NOT NULL,
 CONSTRAINT [PK_Tickets_1] PRIMARY KEY CLUSTERED 
(
	[IDticket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Канада         ', 1)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Россия         ', 2)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'США            ', 3)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Франция        ', 4)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Китай          ', 5)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Япония         ', 6)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Южная Корея    ', 7)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Нигерия        ', 8)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'ЮАР            ', 9)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Австралия      ', 10)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Индия          ', 11)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Турция         ', 12)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Мексика        ', 13)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Египет         ', 14)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Беларусь       ', 15)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Украина        ', 16)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Великобритания ', 17)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Северная Корея ', 18)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Польша         ', 19)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Германия       ', 20)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Израиль        ', 21)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Швеция         ', 22)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Словакия       ', 23)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Сербия         ', 24)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Швейцария      ', 25)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Болгария       ', 26)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Дания          ', 27)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Венгрия        ', 28)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Исландия       ', 29)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Австрия        ', 30)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Казахстан      ', 31)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Италия         ', 32)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'СССР           ', 33)
INSERT [dbo].[Countries] ([Country], [idProduction]) VALUES (N'Новая Зеландия ', 34)
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([idGenre], [Genre]) VALUES (1, N'Комедия             ')
INSERT [dbo].[Genres] ([idGenre], [Genre]) VALUES (2, N'Драма               ')
INSERT [dbo].[Genres] ([idGenre], [Genre]) VALUES (3, N'Мелодрама           ')
INSERT [dbo].[Genres] ([idGenre], [Genre]) VALUES (4, N'Боевик              ')
INSERT [dbo].[Genres] ([idGenre], [Genre]) VALUES (5, N'Криминал            ')
INSERT [dbo].[Genres] ([idGenre], [Genre]) VALUES (6, N'Ужасы               ')
INSERT [dbo].[Genres] ([idGenre], [Genre]) VALUES (7, N'Мультфильм          ')
INSERT [dbo].[Genres] ([idGenre], [Genre]) VALUES (8, N'Научная фантастика  ')
INSERT [dbo].[Genres] ([idGenre], [Genre]) VALUES (9, N'Фантастика          ')
INSERT [dbo].[Genres] ([idGenre], [Genre]) VALUES (10, N'Триллер             ')
INSERT [dbo].[Genres] ([idGenre], [Genre]) VALUES (11, N'Детский фильм       ')
INSERT [dbo].[Genres] ([idGenre], [Genre]) VALUES (12, N'Приключения         ')
INSERT [dbo].[Genres] ([idGenre], [Genre]) VALUES (13, N'Спорт               ')
INSERT [dbo].[Genres] ([idGenre], [Genre]) VALUES (14, N'История             ')
INSERT [dbo].[Genres] ([idGenre], [Genre]) VALUES (15, N'Документальный      ')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[Halls] ON 

INSERT [dbo].[Halls] ([IDhall], [NameHall]) VALUES (1, N'3D                            ')
INSERT [dbo].[Halls] ([IDhall], [NameHall]) VALUES (2, N'Диванный                      ')
INSERT [dbo].[Halls] ([IDhall], [NameHall]) VALUES (3, N'Большой                       ')
SET IDENTITY_INSERT [dbo].[Halls] OFF
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (1, N'Дом большой мамочки', 3, 2000, 1, 99)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (2, N'Дом большой мамочки 2', 3, 2006, 1, 100)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (3, N'Голодные игры: Сойка-пересмешница. Часть 1', 3, 2014, 1, 123)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (4, N'Голодные игры: Сойка-пересмешница. Часть 2', 1, 2015, 4, 137)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (5, N'Геошторм', 1, 2017, 8, 109)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (6, N'Тупой и ещё тупее', 1, 1994, 1, 107)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (7, N'Я худею', 1, 2018, 1, 102)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (8, N'Жмурки', 1, 2005, 1, 111)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (9, N'Холоп', 1, 2019, 1, 109)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (10, N'Ёлки 3', 1, 2013, 1, 100)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (11, N'Чебурашка', 1, 2023, 11, 113)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (12, N'Самый лучший день', 3, 2015, 1, 112)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (13, N'Пункт назначения', 1, 2000, 6, 98)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (14, N'Пункт назначения 2', 1, 2003, 6, 90)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (15, N'Пункт назначения 3', 1, 2006, 6, 93)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (16, N'Пункт назначения 4', 1, 2009, 6, 82)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (17, N'Пункт назначения 5', 1, 2011, 6, 92)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (18, N'Поворот не туда', 1, 2003, 6, 85)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (19, N'Коллекционер', 1, 2009, 6, 90)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (20, N'Тайна перевала Дятлова', 1, 2013, 6, 100)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (21, N'Хочу замуж', 3, 2022, 3, 106)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (22, N'Непослушная', 1, 2023, 3, 107)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (23, N'Я — легенда', 1, 2007, 8, 101)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (24, N'По наклонной', 1, 2021, 2, 141)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (25, N'Чернобыль', 1, 2021, 2, 136)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (26, N'Ледяной драйв', 1, 2021, 10, 103)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (28, N'Волк и лев', 2, 2021, 11, 99)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (29, N'Голодные игры', 3, 2012, 4, 144)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (32, N'Американский пирог', 3, 1999, 1, 95)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (33, N'Форсаж', 3, 2001, 5, 106)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (42, N'Форсаж 2', 3, 2003, 5, 108)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (50, N'Форсаж 3', 3, 2006, 4, 104)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (52, N'Большие мамочки: Сын как отец', 3, 2011, 1, 107)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (55, N'Пассажиры', 3, 2016, 8, 116)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (56, N'Робот по имени Чаппи', 3, 2015, 8, 120)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (57, N'Живое', 3, 2017, 8, 110)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (58, N'Брат', 2, 1997, 5, 100)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (59, N'Брат 2', 2, 2000, 5, 127)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (60, N'Мажор в Сочи', 2, 2022, 12, 109)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (61, N'Майор Гром: Чумной Доктор', 2, 2021, 4, 136)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (62, N'Движение вверх', 2, 2017, 13, 133)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (63, N'Калашников', 2, 2020, 1, 104)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (64, N'Зеленая миля', 3, 1999, 2, 189)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (65, N'Форрест Гамп', 3, 1994, 2, 142)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (66, N'1+1', 4, 2011, 2, 112)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (67, N'Джентельмены', 17, 2019, 5, 113)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (68, N'Гладиатор', 3, 2000, 14, 155)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (69, N'Титаник', 3, 1997, 3, 99)
INSERT [dbo].[Movies] ([IDmovie], [NameMovie], [Production], [YearOfIssue], [iGenre], [Duration]) VALUES (71, N'Иван Васильевич меняет профессию', 33, 1973, 1, 88)
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
INSERT [dbo].[Prices] ([IDPrice], [Price], [idHall]) VALUES (2, 6.5000, 1)
INSERT [dbo].[Prices] ([IDPrice], [Price], [idHall]) VALUES (3, 7.5000, 2)
INSERT [dbo].[Prices] ([IDPrice], [Price], [idHall]) VALUES (5, 8.9000, 3)
GO
SET IDENTITY_INSERT [dbo].[Sessions] ON 

INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie], [ID_Session]) VALUES (CAST(N'2023-05-01' AS Date), CAST(N'11:00:00' AS Time), 2, 2, 1)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie], [ID_Session]) VALUES (CAST(N'2023-04-10' AS Date), CAST(N'15:00:00' AS Time), 2, 22, 2)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie], [ID_Session]) VALUES (CAST(N'2023-04-10' AS Date), CAST(N'18:00:00' AS Time), 3, 21, 3)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie], [ID_Session]) VALUES (CAST(N'2023-04-10' AS Date), CAST(N'21:00:00' AS Time), 1, 5, 4)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie], [ID_Session]) VALUES (CAST(N'2023-05-08' AS Date), CAST(N'12:50:00' AS Time), 1, 10, 5)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie], [ID_Session]) VALUES (CAST(N'2023-05-08' AS Date), CAST(N'16:40:00' AS Time), 3, 2, 6)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie], [ID_Session]) VALUES (CAST(N'2023-05-08' AS Date), CAST(N'16:55:00' AS Time), 2, 1, 7)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie], [ID_Session]) VALUES (CAST(N'2023-05-08' AS Date), CAST(N'17:00:00' AS Time), 1, 18, 8)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie], [ID_Session]) VALUES (CAST(N'2023-05-08' AS Date), CAST(N'17:05:00' AS Time), 2, 4, 9)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie], [ID_Session]) VALUES (CAST(N'2023-05-08' AS Date), CAST(N'18:15:00' AS Time), 1, 1, 10)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie], [ID_Session]) VALUES (CAST(N'2023-05-08' AS Date), CAST(N'18:40:00' AS Time), 2, 11, 11)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie], [ID_Session]) VALUES (CAST(N'2023-05-22' AS Date), CAST(N'23:30:00' AS Time), 2, 5, 13)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie], [ID_Session]) VALUES (CAST(N'2023-05-20' AS Date), CAST(N'11:05:00' AS Time), 1, 8, 14)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie], [ID_Session]) VALUES (CAST(N'2023-05-01' AS Date), CAST(N'11:20:00' AS Time), 1, 19, 17)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie], [ID_Session]) VALUES (CAST(N'2023-05-10' AS Date), CAST(N'11:35:00' AS Time), 3, 15, 27)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie], [ID_Session]) VALUES (CAST(N'2023-05-26' AS Date), CAST(N'11:55:00' AS Time), 2, 4, 28)
INSERT [dbo].[Sessions] ([Date], [Time], [Hall], [Movie], [ID_Session]) VALUES (CAST(N'2023-05-27' AS Date), CAST(N'11:55:00' AS Time), 2, 26, 29)
SET IDENTITY_INSERT [dbo].[Sessions] OFF
GO
SET IDENTITY_INSERT [dbo].[Tickets] ON 

INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (15, 1, 2, 0, 1, 5)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (16, 1, 3, 0, 1, 5)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (17, 1, 4, 1, 1, 5)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (18, 1, 7, 1, 1, 5)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (19, 1, 6, 0, 1, 5)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (22, 1, 10, 1, 3, 5)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (23, 1, 1, 0, 1, 5)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (28, 3, 3, 1, 2, 3)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (35, 3, 3, 0, 3, 5)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (36, 3, 3, 1, 4, 2)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (38, 4, 3, 0, 4, 2)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (39, 2, 2, 1, 2, 3)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (44, 9, 8, 0, 8, 2)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (45, 9, 9, 0, 8, 2)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (47, 9, 9, 0, 2, 3)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (48, 9, 9, 0, 14, 2)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (51, 2, 9, 0, 13, 2)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (52, 3, 3, 0, 10, 2)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (53, 3, 3, 1, 11, 3)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (56, 13, 15, 0, 1, 3)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (58, 7, 10, 1, 14, 2)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (59, 1, 2, 0, 14, 2)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (60, 5, 9, 1, 17, 2)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (61, 13, 2, 1, 29, 3)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (62, 3, 3, 0, 28, 3)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (64, 3, 4, 1, 27, 5)
INSERT [dbo].[Tickets] ([IDticket], [Row], [Place], [Sold], [Session], [idPrice]) VALUES (65, 13, 15, 0, 10, 2)
SET IDENTITY_INSERT [dbo].[Tickets] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserPassword], [UserLogin], [idUser]) VALUES (N'admin                         ', N'admin', 1)
INSERT [dbo].[Users] ([UserPassword], [UserLogin], [idUser]) VALUES (N'user                          ', N'user', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [MoviesNameProduction]    Script Date: 24.05.2023 23:05:20 ******/
ALTER TABLE [dbo].[Movies] ADD  CONSTRAINT [MoviesNameProduction] UNIQUE NONCLUSTERED 
(
	[NameMovie] ASC,
	[Production] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [SessionDateTime]    Script Date: 24.05.2023 23:05:20 ******/
ALTER TABLE [dbo].[Sessions] ADD  CONSTRAINT [SessionDateTime] UNIQUE NONCLUSTERED 
(
	[Date] ASC,
	[Time] ASC,
	[Hall] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [TicketPlace]    Script Date: 24.05.2023 23:05:20 ******/
ALTER TABLE [dbo].[Tickets] ADD  CONSTRAINT [TicketPlace] UNIQUE NONCLUSTERED 
(
	[Place] ASC,
	[Row] ASC,
	[Session] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Countries] FOREIGN KEY([Production])
REFERENCES [dbo].[Countries] ([idProduction])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Countries]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Genres] FOREIGN KEY([iGenre])
REFERENCES [dbo].[Genres] ([idGenre])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Genres]
GO
ALTER TABLE [dbo].[Prices]  WITH CHECK ADD  CONSTRAINT [FK_Price_Halls] FOREIGN KEY([idHall])
REFERENCES [dbo].[Halls] ([IDhall])
GO
ALTER TABLE [dbo].[Prices] CHECK CONSTRAINT [FK_Price_Halls]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Halls1] FOREIGN KEY([Hall])
REFERENCES [dbo].[Halls] ([IDhall])
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Halls1]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Movies1] FOREIGN KEY([Movie])
REFERENCES [dbo].[Movies] ([IDmovie])
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Movies1]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Price] FOREIGN KEY([idPrice])
REFERENCES [dbo].[Prices] ([IDPrice])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Price]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Sessions] FOREIGN KEY([Session])
REFERENCES [dbo].[Sessions] ([ID_Session])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Sessions]
GO
/****** Object:  StoredProcedure [dbo].[HallsName]    Script Date: 24.05.2023 23:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HallsName] AS
BEGIN
    SELECT NameHall AS 'Название зала'
    FROM Halls
END;
GO
/****** Object:  StoredProcedure [dbo].[NameMovie]    Script Date: 24.05.2023 23:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NameMovie] AS
BEGIN
    SELECT NameMovie AS 'Название фильма', YearOfIssue AS 'Год выпуска'
    FROM Movies
END;
GO
/****** Object:  StoredProcedure [dbo].[SessionsInfo]    Script Date: 24.05.2023 23:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SessionsInfo] AS
BEGIN
    SELECT Date AS 'Дата', Time AS 'Время', Hall AS 'Зал', NameMovie AS 'Название фильма'
    FROM Sessions
	Join Movies ON Movie = IDmovie;
END;
GO
/****** Object:  StoredProcedure [dbo].[TicketsInfo]    Script Date: 24.05.2023 23:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TicketsInfo] AS
BEGIN
    SELECT Row AS 'Ряд', Place AS 'Место', Sold AS 'Занят/Не занят', Price AS 'Цена'
    FROM Tickets
	Join Prices ON Tickets.idPrice = Prices.IDPrice;
END;
GO
/****** Object:  StoredProcedure [dbo].[UsersInfo]    Script Date: 24.05.2023 23:05:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsersInfo] AS
BEGIN
    SELECT idUser AS 'Номер аккаунта', UserLogin AS 'Логин', UserPassword AS 'Пароль'
    FROM Users
END;
GO
USE [master]
GO
ALTER DATABASE [CinemaSystem] SET  READ_WRITE 
GO
