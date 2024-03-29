USE [master]
GO
/****** Object:  Database [pcbuild]    Script Date: 25-Mar-19 9:28:26 PM ******/
CREATE DATABASE [pcbuild]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'pcbuild', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\pcbuild.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'pcbuild_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\pcbuild_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [pcbuild] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [pcbuild].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [pcbuild] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [pcbuild] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [pcbuild] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [pcbuild] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [pcbuild] SET ARITHABORT OFF 
GO
ALTER DATABASE [pcbuild] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [pcbuild] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [pcbuild] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [pcbuild] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [pcbuild] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [pcbuild] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [pcbuild] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [pcbuild] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [pcbuild] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [pcbuild] SET  ENABLE_BROKER 
GO
ALTER DATABASE [pcbuild] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [pcbuild] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [pcbuild] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [pcbuild] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [pcbuild] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [pcbuild] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [pcbuild] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [pcbuild] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [pcbuild] SET  MULTI_USER 
GO
ALTER DATABASE [pcbuild] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [pcbuild] SET DB_CHAINING OFF 
GO
ALTER DATABASE [pcbuild] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [pcbuild] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [pcbuild] SET DELAYED_DURABILITY = DISABLED 
GO
USE [pcbuild]
GO
/****** Object:  Table [dbo].[table_admin]    Script Date: 25-Mar-19 9:28:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_admin](
	[ad_id] [int] IDENTITY(9123341,1) NOT NULL,
	[ad_name] [nvarchar](50) NOT NULL,
	[ad_age] [int] NOT NULL,
	[ad_phone] [int] NOT NULL,
	[ad_username] [nvarchar](50) NOT NULL,
	[ad_password] [nvarchar](50) NOT NULL,
	[ad_email] [nvarchar](50) NOT NULL,
	[ad_image] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ad_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[table_category]    Script Date: 25-Mar-19 9:28:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_category](
	[cat_id] [int] IDENTITY(31523,1) NOT NULL,
	[cat_name] [nvarchar](100) NOT NULL,
	[cat_image] [nvarchar](max) NOT NULL,
	[cat_fk_ad_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[cat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[table_image]    Script Date: 25-Mar-19 9:28:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_image](
	[img_id] [int] IDENTITY(4521515,1) NOT NULL,
	[img_path] [nvarchar](max) NOT NULL,
	[img_fk_prd_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[img_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[table_invoice]    Script Date: 25-Mar-19 9:28:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_invoice](
	[in_id] [int] IDENTITY(741268,1) NOT NULL,
	[in_date] [nvarchar](20) NOT NULL,
	[in_fk_us_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[in_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[table_product]    Script Date: 25-Mar-19 9:28:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_product](
	[prd_id] [int] IDENTITY(54512,1) NOT NULL,
	[prd_name] [nvarchar](200) NOT NULL,
	[prd_dis] [nvarchar](max) NOT NULL,
	[prd_selprice] [int] NOT NULL,
	[prd_cstprise] [int] NOT NULL,
	[prd_fk_cat_id] [int] NULL,
	[prd_fk_sbcat_id] [int] NULL,
	[prd_fk_ad_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[prd_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[table_sales]    Script Date: 25-Mar-19 9:28:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_sales](
	[sls_id] [int] IDENTITY(456556,1) NOT NULL,
	[sls_qty] [int] NOT NULL,
	[sls_fk_in_id] [int] NULL,
	[sls_fk_prd_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[sls_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[table_stock]    Script Date: 25-Mar-19 9:28:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_stock](
	[st_id] [int] IDENTITY(895617,1) NOT NULL,
	[st_name] [nvarchar](100) NOT NULL,
	[st_qty] [int] NOT NULL,
	[st_date] [nvarchar](20) NOT NULL,
	[st_fk_ad_id] [int] NULL,
	[st_fk_prd_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[st_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[table_sub_category]    Script Date: 25-Mar-19 9:28:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_sub_category](
	[sbcat_id] [int] IDENTITY(56523,1) NOT NULL,
	[sbcat_name] [nvarchar](100) NOT NULL,
	[sbcat_image] [nvarchar](max) NOT NULL,
	[sbcat_fk_ad_id] [int] NULL,
	[sbcat_fk_cat_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[sbcat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[table_user]    Script Date: 25-Mar-19 9:28:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[table_user](
	[us_id] [int] IDENTITY(89789,1) NOT NULL,
	[us_email] [nvarchar](100) NOT NULL,
	[us_password] [nvarchar](50) NOT NULL,
	[us_phone] [int] NOT NULL,
	[us_billingAD] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[us_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[table_category]  WITH CHECK ADD FOREIGN KEY([cat_fk_ad_id])
REFERENCES [dbo].[table_admin] ([ad_id])
GO
ALTER TABLE [dbo].[table_image]  WITH CHECK ADD FOREIGN KEY([img_fk_prd_id])
REFERENCES [dbo].[table_product] ([prd_id])
GO
ALTER TABLE [dbo].[table_invoice]  WITH CHECK ADD FOREIGN KEY([in_fk_us_id])
REFERENCES [dbo].[table_user] ([us_id])
GO
ALTER TABLE [dbo].[table_product]  WITH CHECK ADD FOREIGN KEY([prd_fk_cat_id])
REFERENCES [dbo].[table_category] ([cat_id])
GO
ALTER TABLE [dbo].[table_product]  WITH CHECK ADD FOREIGN KEY([prd_fk_sbcat_id])
REFERENCES [dbo].[table_sub_category] ([sbcat_id])
GO
ALTER TABLE [dbo].[table_product]  WITH CHECK ADD FOREIGN KEY([prd_fk_ad_id])
REFERENCES [dbo].[table_admin] ([ad_id])
GO
ALTER TABLE [dbo].[table_sales]  WITH CHECK ADD FOREIGN KEY([sls_fk_in_id])
REFERENCES [dbo].[table_invoice] ([in_id])
GO
ALTER TABLE [dbo].[table_sales]  WITH CHECK ADD FOREIGN KEY([sls_fk_prd_id])
REFERENCES [dbo].[table_product] ([prd_id])
GO
ALTER TABLE [dbo].[table_stock]  WITH CHECK ADD FOREIGN KEY([st_fk_ad_id])
REFERENCES [dbo].[table_admin] ([ad_id])
GO
ALTER TABLE [dbo].[table_stock]  WITH CHECK ADD FOREIGN KEY([st_fk_prd_id])
REFERENCES [dbo].[table_product] ([prd_id])
GO
ALTER TABLE [dbo].[table_sub_category]  WITH CHECK ADD FOREIGN KEY([sbcat_fk_ad_id])
REFERENCES [dbo].[table_admin] ([ad_id])
GO
ALTER TABLE [dbo].[table_sub_category]  WITH CHECK ADD FOREIGN KEY([sbcat_fk_cat_id])
REFERENCES [dbo].[table_category] ([cat_id])
GO
USE [master]
GO
ALTER DATABASE [pcbuild] SET  READ_WRITE 
GO
