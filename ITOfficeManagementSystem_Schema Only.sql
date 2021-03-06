USE [master]
GO
/****** Object:  Database [ITOfficeManagementSystem]    Script Date: 04-Apr-20 12:36:18 PM ******/
CREATE DATABASE [ITOfficeManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ITOfficeManagementSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ITOfficeManagementSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ITOfficeManagementSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ITOfficeManagementSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ITOfficeManagementSystem] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ITOfficeManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ITOfficeManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ITOfficeManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ITOfficeManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ITOfficeManagementSystem', N'ON'
GO
ALTER DATABASE [ITOfficeManagementSystem] SET QUERY_STORE = OFF
GO
USE [ITOfficeManagementSystem]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 04-Apr-20 12:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Gender] [nvarchar](50) NULL,
	[Contact] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssignTask]    Script Date: 04-Apr-20 12:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignTask](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[TaskTitle] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 04-Apr-20 12:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[AttendanceId] [bigint] IDENTITY(1,1) NOT NULL,
	[LoginStatus] [bit] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[LoginTime] [datetime2](7) NOT NULL,
	[LogoutTime] [datetime2](7) NOT NULL,
	[LoginDuration] [float] NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 04-Apr-20 12:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Contact] [nvarchar](50) NULL,
	[Gender] [nvarchar](50) NULL,
	[OrganizationName] [nvarchar](150) NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 04-Apr-20 12:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Contact] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[DOB] [datetime2](7) NOT NULL,
	[Gender] [nvarchar](50) NULL,
	[JoiningDate] [datetime2](7) NOT NULL,
	[Designation] [nvarchar](50) NULL,
	[BasicSalary] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeSalary]    Script Date: 04-Apr-20 12:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeSalary](
	[SalaryId] [int] IDENTITY(1,1) NOT NULL,
	[BasicSalary] [int] NOT NULL,
	[Tax] [float] NOT NULL,
	[Benifits] [int] NOT NULL,
	[HourPrice] [float] NOT NULL,
	[TotalHourPrice] [float] NOT NULL,
	[Withdraw] [int] NOT NULL,
	[NetSalary] [float] NOT NULL,
	[PaymentStatus] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[AttendanceId] [bigint] NOT NULL,
 CONSTRAINT [PK_EmployeeSalary] PRIMARY KEY CLUSTERED 
(
	[SalaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 04-Apr-20 12:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[EventTitle] [nvarchar](150) NOT NULL,
	[EventDetails] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 04-Apr-20 12:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackId] [int] IDENTITY(1,1) NOT NULL,
	[Reliability] [nvarchar](50) NOT NULL,
	[Design] [nvarchar](50) NOT NULL,
	[EaseOfUse] [nvarchar](50) NOT NULL,
	[Security] [nvarchar](50) NOT NULL,
	[AbilityToIntegrate] [nvarchar](50) NOT NULL,
	[AbilityToCollaborate] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ClientId] [int] NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[FeedbackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notice]    Script Date: 04-Apr-20 12:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notice](
	[NoticeId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[Details] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Notice] PRIMARY KEY CLUSTERED 
(
	[NoticeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 04-Apr-20 12:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04-Apr-20 12:36:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[ConfirmPassword] [nvarchar](50) NOT NULL,
	[UserRoleId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [ITOfficeManagementSystem] SET  READ_WRITE 
GO
